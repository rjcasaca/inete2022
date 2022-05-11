using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Worklog;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IWorklogRepository
    {
        public bool Create(PostWorklog worklog);
        public Worklog Read(int id);
        public bool Update(PutWorklog worklog);
        public bool Delete(int id);
    }

    public class WorklogRepository:IWorklogRepository
    {
        private readonly _DbContext db;

        public WorklogRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostWorklog worklog)
        {
            try
            {
                var worklog_db = new Worklog()
                {
                    User = worklog.User,
                    Activity = worklog.Activity,
                    Date = worklog.Date,
                    Hours = worklog.Hours,
                    Comment = worklog.Comment,
                    WorklogState = worklog.WorklogState,
                    BillingType = worklog.BillingType
                };
                db.worklogs.Add(worklog_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Worklog Read(int id)
        {
            try
            {
                var worklog_db = db.worklogs.Find(id);

                return worklog_db;
            }
            catch
            {
                return new Worklog();
            }
        }

        public bool Update(PutWorklog worklog)
        {
            try
            {
                var worklog_db = db.worklogs.Find(worklog.Cod_Worklog);
                worklog_db.User = worklog.User;
                worklog_db.Activity = worklog.Activity;
                worklog_db.Date = worklog.Date;
                worklog_db.Hours = worklog.Hours;
                worklog_db.Comment = worklog.Comment;
                worklog_db.WorklogState = worklog.WorklogState;
                worklog_db.BillingType = worklog.BillingType;
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
                var worklog_db = db.worklogs.Find(id);
                db.worklogs.Remove(worklog_db);
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
