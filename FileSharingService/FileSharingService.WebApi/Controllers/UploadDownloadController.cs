using Common.Entity.FileService;
using FileSharingService.Bll.BusinessLogic;
using FileSharingService.WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileSharingService.WebApi.Controllers
{
    [ApiController]
    public class UploadDownloadController : ControllerBase
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IBusinessLogic db;

        public UploadDownloadController(IHostingEnvironment hostingEnvironment, IBusinessLogic db)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.db = db;
        }

        [HttpPost]
        [Route("api/files/upload")]
        public async Task<IActionResult> Upload([FromForm] CreateFileModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var uploads = Path.Combine(hostingEnvironment.ContentRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (model.File.Length > 0)
            {
                var filePath = Path.Combine(uploads, model.File.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                }
            }
            var file = new Common.Entity.FileService.File();

            file.DownloadDate = DateTime.Now;
            file.FileAccessId = Convert.ToInt32(model.AccessId);
            file.CategoryId = Convert.ToInt32(model.CategoryId);
            file.Description = model.Description;
            file.Name = model.File.FileName;
            file.Size = model.File.Length;

            var fileUrl = new FileUrl();
            fileUrl.Url = uploads;

            var newFileUrl = db.FileUrls.Create(fileUrl);

            if(newFileUrl == null)
            {
                return BadRequest();
            }

            file.UserId = 1;
            file.FileUrlId = newFileUrl.Id;

            FileCard newFile = db.Files.Create(file);

            if(newFile == null)
            {
                return BadRequest();
            }

            return Ok(newFile);
        }

        [HttpGet]
        [Route("api/files/download")]
        public async Task<IActionResult> Download([FromQuery] string file)
        {
            var uploads = Path.Combine(hostingEnvironment.ContentRootPath, "uploads");
            var filePath = Path.Combine(uploads, file);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), file);
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}