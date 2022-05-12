using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.ActivityState;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IActivityStateRepository
    {
        public bool Create(PostActivityState activityState);
        public ActivityState Read(int id);
        public bool Update(PutActivityState activityState);
        public bool Delete(int id);
    }

    public class ActivityStateRepository:IActivityStateRepository
    {
        private readonly _DbContext db;

        public ActivityStateRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostActivityState activityState)
        {
            try
            {
                var activityState_db = new ActivityState()
                {
                    State = activityState.State
                };
                db.activityState.Add(activityState_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ActivityState Read(int id)
        {
            try
            {
                var activityState_db = db.activityState.Find(id);

                return activityState_db;
            }
            catch
            {
                return new ActivityState();
            }
        }

        public bool Update(PutActivityState activityState)
        {
            try
            {
                var activityState_db = db.activityState.Find(activityState.ActivityState_Id);
                activityState_db.State = activityState.State;
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
                var activityState_db = db.activityState.Find(id);
                db.activityState.Remove(activityState_db);
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
