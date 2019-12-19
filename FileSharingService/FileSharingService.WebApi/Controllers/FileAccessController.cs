using Common.Entity.FileService;
using FileSharingService.Bll.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FileSharingService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileAccessController : ControllerBase
    {
        private readonly IBusinessLogic db;

        public FileAccessController(IBusinessLogic db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<FileAccess> Get()
        {
            return db.FileAccesses.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            FileAccess item = db.FileAccesses.GetItemById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FileAccess model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            FileAccess access = db.FileAccesses.Create(model);

            if (access == null)
            {
                return BadRequest();
            }

            return Ok(access);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FileAccess model)
        {
            if (model == null || model.Id == id)
            {
                return BadRequest();
            }

            db.FileAccesses.Update(model);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            if (db.FileAccesses.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}