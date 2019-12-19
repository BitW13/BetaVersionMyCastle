using Common.Entity.FileService;
using FileSharingService.Bll.Services.Interfaces;
using FileSharingService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FileSharingService.Bll.Services.Implementations
{
    public class FileUrlService : IFileUrlService
    {
        private readonly IFileUrlRepository db;

        public FileUrlService(IFileUrlRepository db)
        {
            this.db = db;
        }

        public FileUrl Create(FileUrl item)
        {
            db.Create(item);

            var items = GetAll().ToList();

            return items[0];
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public IEnumerable<FileUrl> GetAll()
        {
            return db.GetAll();
        }

        public FileUrl GetItemById(int id)
        {
            return db.GetItemById(id);
        }

        public void Update(FileUrl item)
        {
            db.Update(item);
        }
    }
}
