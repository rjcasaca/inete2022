using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.File;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IFileRepository
    {
        public bool Create(PostFile file);
        public Models.File Read(int id);
        public bool Update(PutFile file);
        public bool Delete(int id);
    }

    public class FileRepository:IFileRepository
    {
        private readonly _DbContext db;

        public FileRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostFile file)
        {
            try
            {
                var file_db = new Models.File()
                {
                    base64 = file.base64
                };
                db.files.Add(file_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Models.File Read(int id)
        {
            try
            {
                var file_db = db.files.Find(id);

                return file_db;
            }
            catch
            {
                return new Models.File();
            }
        }

        public bool Update(PutFile file)
        {
            try
            {
                var file_db = db.files.Find(file.File_Id);
                file_db.base64 = file.base64;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var file_db = db.files.Find(id);
                db.files.Remove(file_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
