using System.ComponentModel.DataAnnotations;

namespace TaskPlannerService.WebApi.Models
{
    public class CreateTask
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int TaskCategoryId { get; set; }

        public int PlannerDateId { get; set; }

        public bool IsDone { get; set; }

        public int BoardId { get; set; }
    }
}
