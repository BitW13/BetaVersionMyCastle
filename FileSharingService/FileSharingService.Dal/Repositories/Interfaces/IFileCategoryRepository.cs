using Common.Entity.FileService;
using Common.Patterns.Repository;

namespace FileSharingService.Dal.Repositories.Interfaces
{
    public interface IFileCategoryRepository : IRepository<FileCategory>
    {
        FileCategory GetItemByName(FileCategory item);
    }
}
