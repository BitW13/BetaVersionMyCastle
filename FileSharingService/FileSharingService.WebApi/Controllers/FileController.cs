using Common.Entity.FileService;
using FileSharingService.Bll.BusinessLogic;
using FileSharingService.WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSharingService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IBusinessLogic db;
        private readonly IHostingEnvironment hostingEnvironment;

        public FileController(IHostingEnvironment hostingEnvironment, IBusinessLogic db)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IEnumerable<FileCard> Get()
        {
            return db.Files.GetFileCards();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            FileCard item = db.Files.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FileCard model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            model.File.DownloadDate = DateTime.Now;
            model.File.FileAccessId = model.FileAccess.Id;
            model.File.CategoryId = model.FileCategory.Id;

            FileCard file = db.Files.Create(model.File);

            return Ok(file);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Common.Entity.FileService.File model)
        {
            if (model == null || id != model.Id)
            {
                return BadRequest();
            }

            db.Files.Update(model);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }

            var uploads = Path.Combine(hostingEnvironment.ContentRootPath, "uploads");

            if (!Directory.Exists(uploads))
            {
                return NotFound();
            }

            var file = db.Files.GetItemById(id);

            var filePath = Path.Combine(uploads, file.Name);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            if (!db.Files.Delete(id))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}