using Common.Entity.FileService;
using FileSharingService.Bll.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FileSharingService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUrlController : ControllerBase
    {
        private readonly IBusinessLogic db;

        public FileUrlController(IBusinessLogic db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<FileUrl> Get()
        {
            return db.FileUrls.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            FileUrl item = db.FileUrls.GetItemById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(FileUrl model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            FileUrl item = db.FileUrls.Create(model);

            if (item == null)
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FileUrl model)
        {
            if (model == null || model.Id != id)
            {
                return BadRequest();
            }

            db.FileUrls.Update(model);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            if (db.FileUrls.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}