using System.ComponentModel.DataAnnotations;

namespace TaskPlannerService.WebApi.Models
{
    public class CreateSeverity
    {
        public string Name { get; set; }

        public int BoardId { get; set; }
    }
}
