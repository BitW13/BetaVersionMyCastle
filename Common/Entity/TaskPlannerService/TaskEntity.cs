using System.ComponentModel.DataAnnotations;

namespace Common.Entity.TaskPlannerService
{
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TaskCategoryId { get; set; }

        public int SeverityId { get; set; }

        public int PlannerDateId { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
