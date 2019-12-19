using System.ComponentModel.DataAnnotations;

namespace TaskPlannerService.WebApi.Models
{
    public class CreateTaskCategory
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public string ImagePath { get; set; }

        public bool IsOn { get; set; }

        public int BoardId { get; set; }
    }
}
