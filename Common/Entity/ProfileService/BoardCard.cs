using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entity.ProfileService
{
    public class BoardCard
    {
        [Required]
        public Board Board { get; set; }

        [Required]
        public List<string> Users { get; set; }
    }
}
