using Common.Entity.FileService;
using Common.Patterns.Repository;
using System.Collections.Generic;

namespace FileSharingService.Dal.Repositories.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        IEnumerable<FileCard> GetFileCards();

        FileCard Get(int id);
    }
}
