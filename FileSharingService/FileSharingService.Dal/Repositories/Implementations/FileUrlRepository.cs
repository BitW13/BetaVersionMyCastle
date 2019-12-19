using Common.Entity.FileService;
using Common.Interfaces;
using FileSharingService.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharingService.Dal.Repositories.Implementations
{
    public class FileUrlRepository : IFileUrlRepository
    {
        private readonly IContext db;

        public FileUrlRepository(IContext db)
        {
            this.db = db;
        }

        public void Create(FileUrl item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Url", item.Url, DbType.String),
            };

            db.Insert("CreateFileUrl", CommandType.StoredProcedure, parameters.ToArray());
        }

        public bool Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };
            try
            {
                db.Delete("DeleteFileUrl", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<FileUrl> GetAll()
        {
            var fileUrlDataTable = db.GetDataTable("GetFileUrls", CommandType.StoredProcedure);
            var fileUrls = new List<FileUrl>();
            foreach (DataRow row in fileUrlDataTable.Rows)
            {
                var fileUrl = new FileUrl
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Url = row["Url"].ToString()
                };
                fileUrls.Add(fileUrl);
            }
            return fileUrls;
        }

        public FileUrl GetItemById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            var fileUrlDataTable = db.GetDataTable("GetFileUrlById", CommandType.StoredProcedure, parameters.ToArray());

            var fileUrls = new List<FileUrl>();
            foreach (DataRow row in fileUrlDataTable.Rows)
            {
                var fileUrl = new FileUrl
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Url = row["Url"].ToString()
                };
                fileUrls.Add(fileUrl);
            }
            return fileUrls[0];
        }

        public void Update(FileUrl item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", item.Id, DbType.Int32),
                db.CreateParameter("@Url", item.Url, DbType.String)
            };

            db.Update("UpdateFileUrl", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
