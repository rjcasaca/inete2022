using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.ActivityType;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IActivityTypeRepository
    {
        public bool Create(PostActivityType activityType);
        public ActivityType Read(int id);
        public bool Update(PutActivityType activityType);
        public bool Delete(int id);
    }

    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly _DbContext db;

        public ActivityTypeRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostActivityType activityType)
        {
            try
            {
                var activityType_db = new ActivityType()
                {
                    Type = activityType.Type
                };
                db.activityType.Add(activityType_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ActivityType Read(int id)
        {
            try
            {
                var activityType_db = db.activityType.Find(id);

                return activityType_db;
            }
            catch
            {
                return new ActivityType();
            }
        }

        public bool Update(PutActivityType activityType)
        {
            try
            {
                var activityType_db = db.activityType.Find(activityType.ActivityType_Id);
                activityType_db.Type = activityType.Type;
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
                var activityType_db = db.activityType.Find(id);
                db.activityType.Remove(activityType_db);
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
