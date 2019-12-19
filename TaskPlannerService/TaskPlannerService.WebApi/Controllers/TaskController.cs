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
    public class TaskController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPresenterLayer db;

        public TaskController(IPresenterLayer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<TaskCard> Get()
        {
            return db.Cards.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TaskCard card = db.Cards.GetItemById(id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateTask model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            TaskEntity task = mapper.Map<TaskEntity>(model);

            if (task == null)
            {
                return BadRequest();
            }

            TaskCard card = db.Cards.Create(task);

            if (card == null)
            {
                return BadRequest();
            }

            return Ok(card);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TaskEntity task)
        {
            if (task == null || id != task.Id)
            {
                return BadRequest();
            }

            TaskCard card = db.Cards.Update(task);

            if (card == null)
            {
                return BadRequest();
            }

            return Ok(card);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (db.Cards.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}