using Common.Entity.FileService;
using Common.Interfaces;
using FileSharingService.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharingService.Dal.Repositories.Implementations
{
    public class FileAccessRepository : IFileAccessRepository
    {
        private readonly IContext db;

        public FileAccessRepository(IContext db)
        {
            this.db = db;
        }

        public void Create(FileAccess item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Name", item.Name, DbType.String)
            };

            db.Insert("CreateFileAccess", CommandType.StoredProcedure, parameters.ToArray());
        }

        public bool Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            try
            {
                db.Delete("DeleteFileAccess", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<FileAccess> GetAll()
        {
            var fileAccessDataTable = db.GetDataTable("GetFileAccesses", CommandType.StoredProcedure);
            var fileAccesses = new List<FileAccess>();
            foreach (DataRow row in fileAccessDataTable.Rows)
            {
                var fileAccess = new FileAccess
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                fileAccesses.Add(fileAccess);
            }
            return fileAccesses;
        }

        public FileAccess GetItemById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            var fileAccessDataTable = db.GetDataTable("GetFileAccessById", CommandType.StoredProcedure, parameters.ToArray());

            var fileAccesses = new List<FileAccess>();
            foreach (DataRow row in fileAccessDataTable.Rows)
            {
                var fileAccess = new FileAccess
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                fileAccesses.Add(fileAccess);
            }
            return fileAccesses[0];
        }

        public void Update(FileAccess item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", item.Id, DbType.Int32),
                db.CreateParameter("@Name", item.Name, DbType.String)
            };

            db.Update("UpdateFileAccess", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
