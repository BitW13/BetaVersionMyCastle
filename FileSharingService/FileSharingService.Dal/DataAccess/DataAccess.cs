using FileSharingService.Dal.Repositories.Interfaces;

namespace FileSharingService.Dal.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(IFileAccessRepository fileAccesses,
                            IFileCategoryRepository fileCategories,
                            IFileRepository files,
                            IFileUrlRepository fileUrls)
        {
            FileAccesses = fileAccesses;
            FileCategories = fileCategories;
            Files = files;
            FileUrls = fileUrls;
        }

        public IFileAccessRepository FileAccesses { get; set; }
        public IFileCategoryRepository FileCategories { get; set; }
        public IFileRepository Files { get; set; }
        public IFileUrlRepository FileUrls { get; set; }
    }
}
