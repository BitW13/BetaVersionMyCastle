using System.ComponentModel.DataAnnotations;

namespace Common.Entity.ProfileService
{
    public class Board
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public bool IsFavorite { get; set; }
    }
}
