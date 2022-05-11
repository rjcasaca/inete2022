using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.WorklogState;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IWorklogStateRepository
    {
        public bool Create(PostWorklogState worklogState);
        public WorklogState Read(int id);
        public bool Update(PutWorklogState worklogState);
        public bool Delete(int id);
    }

    public class WorklogStateRepository:IWorklogStateRepository
    {
        private readonly _DbContext db;

        public WorklogStateRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostWorklogState worklogState)
        {
            try
            {
                var worklogState_db = new WorklogState()
                {
                    State = worklogState.State
                };
                db.worklogStates.Add(worklogState_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public WorklogState Read(int id)
        {
            try
            {
                var worklogState_db = db.worklogStates.Find(id);

                return worklogState_db;
            }
            catch
            {
                return new WorklogState();
            }
        }

        public bool Update(PutWorklogState worklogState)
        {
            try
            {
                var worklogState_db = db.worklogStates.Find(worklogState.WorklogState_Id);
                worklogState_db.State = worklogState.State;
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
                var worklogState_db = db.worklogStates.Find(id);
                db.worklogStates.Remove(worklogState_db);
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
