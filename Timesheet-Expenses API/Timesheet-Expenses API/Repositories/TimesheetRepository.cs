using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Timesheet;

namespace Timesheet_Expenses_API.Repositories
{
    public interface ITimesheetRepository
    {
        public int GetUserId(string email);
        public List<TimesheetWorklog> GetUserWorklog(DateTime date, int userId);
        public bool CreateWorklog(PostWorklogTimesheet worklog, int userId);
        public List<ActivityUser> GetActivityUser(int userId);
        public Activity GetActivityInfo(int activityId);
        public Project GetProjectInfo(int projectId);
    }

    public class TimesheetRepository : ITimesheetRepository
    {
        #region variables
        private readonly _DbContext db;
        #endregion

        //Default Constructor
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

        //devolve um lista com o nome e id das atividades relacionadas com o user
        public List<ActivityUser> GetActivityUser(int userId)
        {
            try
            {
                List<ActivityUser> ActivityUsers = new List<ActivityUser>();

                //vai obter todos os projectos relacionados com o user
                List<Team> team_db = db.teams.Where(t => t.UserId.Equals(userId)).ToList();
                List<Activity> activity_users = new List<Activity>();
                //vai obter todas as atividades com os projetos relacionados com o user
                foreach (Team t in team_db)
                {
                    var activity = db.activities.Where(a => a.Project.Project_Id.Equals(t.ProjectId)).ToList();
                    foreach (Activity a in activity)
                    {
                        activity_users.Add(a);
                    }
                }

                //adiciona o nome e o id a um objeto, o mesmo é depois adicionado a uma lista de objetos do mesmo tipo
                foreach (Activity a in activity_users)
                {
                    var at_u = new ActivityUser
                    {
                        ActivityId = a.Activity_Id,
                        ActivityName = a.Name
                    };
                    ActivityUsers.Add(at_u);
                }

                return ActivityUsers;
            }
            catch
            {
                return new List<ActivityUser>();
            }
        }

        //recebe um id da atividade selecionada e devolve a informação de todos os campos da mesma
        public Activity GetActivityInfo(int activityId)
        {
            try
            {
                var activityInfo = db.activities.Find(activityId);
                return activityInfo;
            }
            catch
            {
                return new Activity();
            }
        }

        //recebe um id de um porjecto selecionado e devolve a informação de todos os campos do mesmo
        public Project GetProjectInfo(int projectId)
        {
            try
            {
                var projectInfo = db.projects.Find(projectId);
                return projectInfo;
            }
            catch
            {
                return new Project();
            }
        }
    }
}
