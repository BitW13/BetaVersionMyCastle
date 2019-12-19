using Common.Entity.FileService;
using Common.Patterns.Repository;
using System.Collections.Generic;

namespace FileSharingService.Bll.Services.Interfaces
{
    public interface IFileService : IService<File>
    {
        IEnumerable<FileCard> GetFileCards();

        FileCard Get(int id);

        FileCard Create(File item);
    }
}
