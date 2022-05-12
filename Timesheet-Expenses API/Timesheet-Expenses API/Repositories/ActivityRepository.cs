using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Activity;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IActivityRepository
    {
        public bool Create(PostActivity activity);
        public Activity Read(int id);
        public bool Update(PutActivity activity);
        public bool Delete(int id);
    }

    public class ActivityRepository : IActivityRepository
    {
        private readonly _DbContext db;

        public ActivityRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostActivity activity)
        {
            try
            {
                var activity_db = new Activity()
                {
                    Project = activity.Project,
                    Name = activity.Name,
                    ActivityState = activity.ActivityState,
                    ActivityType = activity.ActivityType,
                    Description = activity.Description
                };
                db.activities.Add(activity_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Activity Read(int id)
        {
            try
            {
                var activity_db = db.activities.Find(id);

                return activity_db;
            }
            catch
            {
                return new Activity();
            }
        }

        public bool Update(PutActivity activity)
        {
            try
            {
                var activity_db = db.activities.Find(activity.Activity_Id);
                activity_db.Project = activity.Project;
                activity_db.Name = activity.Name;
                activity_db.ActivityState = activity.ActivityState;
                activity_db.ActivityType = activity.ActivityType;
                activity_db.Description = activity.Description;
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
                var activity_db = db.activities.Find(id);
                db.activities.Remove(activity_db);
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
