using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Entity.NoteService
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime LastChange { get; set; }

        [Required]
        public int NoteCategoryId { get; set; }

        [Required]
        public int BoardId { get; set; }
    }
}
