using System.ComponentModel.DataAnnotations;

namespace Common.Entity.TaskPlannerService
{
    public class Severity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
