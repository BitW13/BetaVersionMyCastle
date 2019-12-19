namespace Common.Entity.FileService
{
    public class FileCard
    {
        public File File { get; set; }

        public FileAccess FileAccess { get; set; }

        public FileCategory FileCategory { get; set; }

        public FileUrl FileUrl { get; set; }
    }
}
