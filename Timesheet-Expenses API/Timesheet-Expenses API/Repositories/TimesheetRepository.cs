using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Timesheet;

namespace Timesheet_Expenses_API.Repositories
{
    public interface ITimesheetRepository
    {
        public int GetUserId(string email);
        public List<TimesheetWorklog> GetUserWorklog(DateTime date);
        public bool CreateWorklog(PostWorklog worklog);
    }

    public class TimesheetRepository:ITimesheetRepository
    {
        #region variables
        private readonly _DbContext db;
        private int userId;
        private List<TimesheetWorklog> TimesheetWorklogs;
        #endregion

        public TimesheetRepository(_DbContext _db)
        {
            db = _db;
        }

        //recebe o email do utilizador e devolde o id do mesmo
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

        //recebe a data indicada e devolve uma lista com todas as worklogs do user
        public List<TimesheetWorklog> GetUserWorklog(DateTime date)
        {
            try
            {
                //vai percorrer a semana toda e adicionar todas as worklogs da semana
                List<Worklog> worklog = new List<Worklog>();
                for (int i = 0; i < 7; i++)
                {
                    worklog = db.worklogs.Where(wl => wl.User.Equals(userId) && wl.Date.Equals(date.AddDays(i))).ToList();
                }

                //todos os ids das diferentes atividades da worklog
                var activitiesId = worklog.Select(wl => wl.Activity.Activity_Id).Distinct().ToList();
                foreach (int i in activitiesId)
                {
                    //cria um novo objecto do tipo TimesheetWorklog sempre que começa o ciclo
                    TimesheetWorklog tw = new TimesheetWorklog();
                    tw.ActivityId = i;
                    foreach (Worklog wl in worklog)
                    {
                        if (i == wl.Activity.Activity_Id)
                        {
                            tw.Worklog.Add(wl);
                        }
                    }
                    TimesheetWorklogs.Add(tw);
                }


                return TimesheetWorklogs;
            }
            catch
            {
                return new List<TimesheetWorklog>();
            }
        }

        public bool CreateWorklog(PostWorklog worklog)
        {
            try
            {
                var worklog_db = new Worklog
                {
                    Date = worklog.Date,
                    Hours = worklog.Hours,
                    Comment = worklog.Comment,
                    User = db.users.Find(userId),
                    Activity = db.activities.Find(worklog.Activity),
                    WorklogState = db.worklogStates.Find(db.worklogStates.Where(ws => ws.State.Equals(worklog.WorklogState)).FirstOrDefault().WorklogState_Id),
                    BillingType = db.billingTypes.Find(db.billingTypes.Where(bt => bt.Type.Equals(worklog.BillingType)).FirstOrDefault().BillingType_Id)
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
    }
}
