using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entity.ShoppingPlannerService
{
    public class ShoppingCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public bool IsOn { get; set; }

        [Required]
        public int BoardId { get; set; }
    }
}
