using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entity.CalendarService
{
    public class CalendarTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CalendarTaskCategoryId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool IsDone { get; set; }
    }
}
