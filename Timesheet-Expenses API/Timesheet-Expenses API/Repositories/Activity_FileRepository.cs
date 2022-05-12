using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Activity_File;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IActivity_FileRepository
    {
        public bool Create(PostActivity_File activity_File);
        public Activity_File Read(int aid, int fid);
        public bool Update(PutActivity_File activity_File);
        public bool Delete(int aid, int fid);
    }

    public class Activity_FileRepository:IActivity_FileRepository
    {
        private readonly _DbContext db;

        public Activity_FileRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostActivity_File activity_File)
        {
            try
            {
                var activity_File_db = new Activity_File()
                {
                    FileContent = activity_File.FileContent,
                    Activity = activity_File.Activity
                };
                db.activities_files.Add(activity_File_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Activity_File Read(int aid, int fid)
        {
            try
            {
                var activity_File_db = db.activities_files.Find(aid, fid);

                return activity_File_db;
            }
            catch
            {
                return new Activity_File();
            }
        }

        public bool Update(PutActivity_File activity_File)
        {
            try
            {
                var activity_File_db = db.activities_files.Find(activity_File.ActivityId, activity_File.FileContentId);
                activity_File_db.Activity = activity_File.Activity;
                activity_File_db.FileContent = activity_File.FileContent;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int aid, int fid)
        {
            try
            {
                var activity_File_db = db.activities_files.Find(aid, fid);
                db.activities_files.Remove(activity_File_db);
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
