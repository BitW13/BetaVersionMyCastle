using AutoMapper;
using Common.Entity.TaskPlannerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskPlannerService.PL;
using TaskPlannerService.WebApi.Models;

namespace TaskPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPresenterLayer db;

        public TaskCategoryController(IMapper mapper, IPresenterLayer db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<TaskCategory> Get()
        {
            return db.Categories.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TaskCategory category = db.Categories.GetItemById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPost]
        public IActionResult Post([FromBody]CreateTaskCategory model)
        {
            TaskCategory category;

            if (model == null)
            {
                return BadRequest();
            }

            category = mapper.Map<TaskCategory>(model);

            if (category == null)
            {
                return BadRequest();
            }

            category = db.Categories.Create(category);

            if (category == null)
            {
                return BadRequest();
            }

            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TaskCategory category)
        {
            if (category == null || id != category.Id)
            {
                return BadRequest();
            }

            category = db.Categories.Update(category);

            if (category == null)
            {
                BadRequest();
            }

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (db.Categories.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}