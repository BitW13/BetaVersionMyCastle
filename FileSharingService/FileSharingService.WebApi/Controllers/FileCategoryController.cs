using Common.Entity.FileService;
using FileSharingService.Bll.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FileSharingService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileCategoryController : ControllerBase
    {
        private readonly IBusinessLogic db;

        public FileCategoryController(IBusinessLogic db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<FileCategory> Get()
        {
            return db.FileCategories.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            FileCategory item = db.FileCategories.GetItemById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FileCategory model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if(model.Name == null)
            {
                model.Name = "Категория";
            }

            FileCategory category = db.FileCategories.Create(model);

            if (category == null)
            {
                return BadRequest();
            }

            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FileCategory model)
        {
            if (model == null || id != model.Id)
            {
                return BadRequest();
            }

            db.FileCategories.Update(model);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            if (db.FileCategories.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}