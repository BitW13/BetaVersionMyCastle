using FileSharingService.Dal.Repositories.Interfaces;

namespace FileSharingService.Dal.DataAccess
{
    public interface IDataAccess
    {
        IFileAccessRepository FileAccesses { get; set; }

        IFileCategoryRepository FileCategories { get; set; }

        IFileRepository Files { get; set; }

        IFileUrlRepository FileUrls { get; set; }
    }
}
