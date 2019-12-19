using Common.Entity.FileService;
using Common.Patterns.Repository;

namespace FileSharingService.Dal.Repositories.Interfaces
{
    public interface IFileAccessRepository : IRepository<FileAccess>
    {
    }
}
