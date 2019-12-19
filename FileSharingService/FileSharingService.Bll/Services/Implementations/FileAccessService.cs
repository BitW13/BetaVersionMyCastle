using Common.Entity.FileService;
using FileSharingService.Bll.Services.Interfaces;
using FileSharingService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FileSharingService.Bll.Services.Implementations
{
    public class FileAccessService : IFileAccessService
    {
        private readonly IFileAccessRepository db;

        public FileAccessService(IFileAccessRepository db)
        {
            this.db = db;
        }

        public FileAccess Create(FileAccess item)
        {
            db.Create(item);

            var items = GetAll().ToList();

            return items[0];
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public IEnumerable<FileAccess> GetAll()
        {
            return db.GetAll();
        }

        public FileAccess GetItemById(int id)
        {
            return db.GetItemById(id);
        }

        public void Update(FileAccess item)
        {
            db.Update(item);
        }
    }
}
