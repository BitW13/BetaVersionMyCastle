using System.ComponentModel.DataAnnotations;

namespace Common.Entity.ProfileService
{
    public class UserBoard
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int BoardId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
