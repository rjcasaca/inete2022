using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Timesheet;

namespace Timesheet_Expenses_API.Repositories
{
    public interface ITimesheetRepository
    {
        public int GetUserId(string email);
        public List<TimesheetWorklog> GetUserWorklog(DateTime date, int userId);
        public bool CreateWorklog(PostWorklogTimesheet worklog, int userId);
        public bool UpdateWorklog(PutWorklogTimesheet worklog);
        public bool DeleteWorklog(int worklogId);
        public List<ActivityUser> GetActivityUser(int userId, int projectId);
    }

    public class TimesheetRepository : ITimesheetRepository
    {
        #region variables
        private readonly _DbContext db;
        #endregion

        //Default-Constructor
        public TimesheetRepository(_DbContext _db)
        {
            db = _db;
        }

        //recebe o email do utilizador e devolde o id do mesmo (o id vai ser guardado em cache na app utilizada)
        public int GetUserId(string email)
        {
            try
            {
                int userId = db.users.Where(u => u.Email.Equals(email)).FirstOrDefault().User_Id;

                return userId;
            }
            catch
            {
                return 0;
            }
        }

        //recebe a data indicada e devolve uma lista com todas as worklogs do user
        public List<TimesheetWorklog> GetUserWorklog(DateTime date, int userId)
        {
            try
            {
                List<TimesheetWorklog> TimesheetWorklogs = new List<TimesheetWorklog>();

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

        //cria um objecto do tipo Worklog e adiciona os dados do mesmo à base de dados
        public bool CreateWorklog(PostWorklogTimesheet worklog, int userId)
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
                //adiciona à base de dados e salva as alterações
                db.worklogs.Add(worklog_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //recebe os novos valores de uma worklog e atualiza os mesmos
        public bool UpdateWorklog(PutWorklogTimesheet worklog)
        {
            try
            {
                //procura o registo com o id indicado
                var worklog_db = db.worklogs.Find(worklog.worklogId);
                //atualiza os dados igualando os mesmos
                worklog_db.Date = worklog.Date;
                worklog_db.Hours = worklog.Hours;
                worklog_db.Comment = worklog.Comment;
                worklog_db.Activity = db.activities.Find(worklog.Activity);
                worklog_db.WorklogState = db.worklogStates.Find(db.worklogStates.Where(ws => ws.State.Equals(worklog.WorklogState)).FirstOrDefault().WorklogState_Id);
                worklog_db.BillingType = db.billingTypes.Find(db.billingTypes.Where(bt => bt.Type.Equals(worklog.BillingType)).FirstOrDefault().BillingType_Id);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //recebe um id de uma worklog e elimina a mesma da base de dados
        public bool DeleteWorklog(int worklogId)
        {
            try
            {
                //procura a worklog com o id recebido
                var worklog_db = db.worklogs.Find(worklogId);
                db.worklogs.Remove(worklog_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //devolve um lista com o nome e id das atividades relacionadas com o user
        public List<ActivityUser> GetActivityUser(int userId, int projectId)
        {
            try
            {
                List<ActivityUser> ActivityUsers = new List<ActivityUser>();

                var userActivity_db = db.activities_users.Where(ua => ua.UserId.Equals(userId)).ToList();
                List<int> activitiesIds = new List<int>();
                foreach (User_Activity ua in userActivity_db)
                {
                    activitiesIds.Add(ua.ActivityId);
                }

                var activities = db.activities.Where(a => a.Project.Project_Id.Equals(projectId)).ToList();
                foreach (Activity a in activities)
                {
                    foreach (int i in activitiesIds)
                    {
                        if (a.Activity_Id == i)
                        {
                            ActivityUser actUser = new ActivityUser();
                            actUser.ActivityId = a.Activity_Id;
                            actUser.ActivityName = a.Name;
                            ActivityUsers.Add(actUser);
                        }
                    }
                }

                return ActivityUsers;
            }
            catch
            {
                return new List<ActivityUser>();
            }
        }
    }
}
