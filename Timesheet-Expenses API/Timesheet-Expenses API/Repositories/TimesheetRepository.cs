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
        public List<ActivityInfo> GetActivityUser(int userId, int projectId);
        public List<UserProjectsInfo> GetProjectUser(int userId);
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
                    List<Worklog> worklogAux = db.worklogs.Where(wl => wl.User.User_Id.Equals(userId)&& wl.Date.Equals(date.AddDays(i))).ToList();
                    foreach (Worklog w in worklogAux)
                    {
                        worklog.Add(w);
                    }
                }

                //todos os ids das diferentes atividades da worklog
                List<ActivityInfo> activitiesInfos = new List<ActivityInfo>();
                foreach (Worklog wl in worklog)
                {
                    bool aux = false;
                    foreach (ActivityInfo ai in activitiesInfos)
                    {
                        if (ai.ActivityId == wl.ActivityId)
                        {
                            aux = true;
                            break;
                        }
                    }
                    if (aux == false)
                    {
                        ActivityInfo actInfo = new ActivityInfo();
                        actInfo.ActivityId = wl.ActivityId;
                        actInfo.ActivityName = db.activities.Find(wl.ActivityId).Name;
                        activitiesInfos.Add(actInfo);
                    }
                }

                foreach (ActivityInfo ai in activitiesInfos)
                {
                    List<WorklogInfo> worklogInfos = new List<WorklogInfo>();
                    TimesheetWorklog tw = new TimesheetWorklog();
                    tw.Activity = ai;
                    foreach (Worklog wl in worklog)
                    {
                        if (ai.ActivityId == wl.ActivityId)
                        {
                            WorklogInfo wli = new WorklogInfo();
                            wli.worklogId = wl.Cod_Worklog;
                            wli.Hours = wl.Hours;
                            wli.Date = wl.Date;
                            worklogInfos.Add(wli);
                        }
                    }
                    tw.WeekWorklog = worklogInfos;
                    
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

        //recebe um id do user e um id do projecto selecionado, devolve uma lista com o nome e id das atividades relacionadas com o user
        public List<ActivityInfo> GetActivityUser(int userId, int projectId)
        {
            try
            {
                List<ActivityInfo> ActivityUsers = new List<ActivityInfo>();

                //lista de User_Activity com apenas o userId indicado
                var userActivity_db = db.activities_users.Where(ua => ua.UserId.Equals(userId)).ToList();
                //adicionar os ids das atividades relacionadas ao user incicados a uma lista de números inteiros
                List<int> activitiesIds = new List<int>();
                foreach (User_Activity ua in userActivity_db)
                {
                    activitiesIds.Add(ua.ActivityId);
                }

                //lista de Activity com apenas o projectId indicado
                var activities = db.activities.Where(a => a.Project.Project_Id.Equals(projectId)).ToList();
                //comparar os ids das atividades relacionadas com o user indicado com os ids das atividades relacionadas com o projecto indicado
                foreach (Activity a in activities)
                {
                    foreach (int i in activitiesIds)
                    {
                        //caso seja igual adicionar o mesmo à lista
                        if (a.Activity_Id == i)
                        {
                            ActivityInfo actUser = new ActivityInfo();
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
                return new List<ActivityInfo>();
            }
        }

        //recebe o id do user e devolve uma liste com o nome e id de todos os projetos ao qual está relacionado
        public List<UserProjectsInfo> GetProjectUser(int userId)
        {
            try
            {
                var team = db.teams.Where(t => t.UserId.Equals(userId)).ToList();
                List<UserProjectsInfo> projectsInfo = new List<UserProjectsInfo>();
                foreach (Team t in team)
                {
                    var proj = db.projects.Find(t.ProjectId);
                    var pInfo = new UserProjectsInfo();
                    pInfo.projectId = proj.Project_Id;
                    pInfo.PorjectName = proj.Name;
                    projectsInfo.Add(pInfo);
                }

                return projectsInfo;
            }
            catch
            {
                return new List<UserProjectsInfo>();
            }
        }
    }
}
