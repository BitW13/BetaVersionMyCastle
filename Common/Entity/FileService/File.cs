using System;

namespace Common.Entity.FileService
{
    public class File
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Size { get; set; }

        public string Description { get; set; }

        public DateTime DownloadDate { get; set; }

        public int CategoryId { get; set; }

        public int FileAccessId { get; set; }

        public int FileUrlId { get; set; }

        public int UserId { get; set; }
    }
}
