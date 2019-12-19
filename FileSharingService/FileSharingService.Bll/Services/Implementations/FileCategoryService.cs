using Common.Entity.FileService;
using FileSharingService.Bll.Services.Interfaces;
using FileSharingService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FileSharingService.Bll.Services.Implementations
{
    public class FileCategoryService : IFileCategoryService
    {
        private readonly IFileCategoryRepository db;

        public FileCategoryService(IFileCategoryRepository db)
        {
            this.db = db;
        }

        public FileCategory Create(FileCategory item)
        {
            db.Create(item);

            var items = GetAll().ToList();

            return items[0];
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public IEnumerable<FileCategory> GetAll()
        {
            return db.GetAll();
        }

        public FileCategory GetItemById(int id)
        {
            return db.GetItemById(id);
        }

        public void Update(FileCategory item)
        {
            db.Update(item);
        }
    }
}
