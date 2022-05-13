using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Timesheet;

namespace Timesheet_Expenses_API.Repositories
{
    public interface ITimesheetRepository
    {
        public int GetUserId(string email);
        public List<Worklog> GetUserWorklog(int userId);
        public Worklog GetWorklogForDay(DateTime date);
    }

    public class TimesheetRepository:ITimesheetRepository
    {
        private readonly _DbContext db;
        private int userId;
        private List<Worklog> worklogList;
        private Worklog worklog;

        public TimesheetRepository(_DbContext _db)
        {
            db = _db;
        }

        public int GetUserId(string email)
        {
            try
            {
                userId = db.users.Where(u => u.Email.Equals(email)).FirstOrDefault().User_Id;

                return userId;
            }
            catch
            {
                return 0;
            }
        }

        public List<Worklog> GetUserWorklog(int userId)
        {
            try
            {
                worklogList = db.worklogs.Where(wl => wl.User.Equals(userId)).ToList();

                return worklogList;
            }
            catch
            {
                return new List<Worklog>();
            }
        }

        public Worklog GetWorklogForDay(DateTime date)
        {
            try
            {
                foreach (Worklog w in worklogList)
                {
                    if(w.Date == date)
                    {
                        worklog = w;
                    }
                }

                return worklog;
            }
            catch
            {
                return new Worklog();
            }
        }
    }
}
