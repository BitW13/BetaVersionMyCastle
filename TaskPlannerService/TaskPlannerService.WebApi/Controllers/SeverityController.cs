using AutoMapper;
using Common.Entity.TaskPlannerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.PL;
using TaskPlannerService.WebApi.Models;

namespace TaskPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeverityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPresenterLayer db;

        public SeverityController(IMapper mapper, IPresenterLayer db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Severity> Get()
        {
            return db.Severities.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Severity severity = db.Severities.GetItemById(id);

            if (severity == null)
            {
                return NotFound();
            }

            return Ok(severity);
        }


        [HttpPost]
        public IActionResult Post([FromBody]CreateSeverity model)
        {
            Severity severity;

            if (model == null)
            {
                return BadRequest();
            }

            severity = mapper.Map<Severity>(model);

            if (severity == null)
            {
                return BadRequest();
            }

            severity = db.Severities.Create(severity);

            if (severity == null)
            {
                return BadRequest();
            }

            return Ok(severity);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Severity severity)
        {
            if (severity == null || id != severity.Id)
            {
                return BadRequest();
            }

            severity = db.Severities.Update(severity);

            if (severity == null)
            {
                BadRequest();
            }

            return Ok(severity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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