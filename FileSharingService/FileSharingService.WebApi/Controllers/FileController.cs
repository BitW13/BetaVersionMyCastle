using Common.Entity.FileService;
using FileSharingService.Bll.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FileSharingService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IBusinessLogic db;

        public FileController(IBusinessLogic db)
        {
            this.db = db;
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
        public IActionResult Post([FromBody] File model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            model.DownloadDate = DateTime.Now;

            FileCard file = db.Files.Create(model);

            return Ok(file);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] File model)
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

            if (!db.Files.Delete(id))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}