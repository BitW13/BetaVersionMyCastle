using Common.Entity.FileService;
using FileSharingService.Bll.Services.Interfaces;
using FileSharingService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FileSharingService.Bll.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IFileRepository db;

        public FileService(IFileRepository db)
        {
            this.db = db;
        }

        public File Create(File item)
        {
            db.Create(item);

            var items = GetAll().ToList();

            return items[0];
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public FileCard Get(int id)
        {
            return db.Get(id);
        }

        public IEnumerable<File> GetAll()
        {
            return db.GetAll();
        }

        public IEnumerable<FileCard> GetFileCards()
        {
            return db.GetFileCards();
        }

        public File GetItemById(int id)
        {
            return db.GetItemById(id);
        }

        public void Update(File item)
        {
            db.Update(item);
        }

        FileCard IFileService.Create(File item)
        {
            db.Create(item);

            var items = GetAll().ToList();

            item = items[0];

            return db.Get(item.Id);
        }
    }
}
