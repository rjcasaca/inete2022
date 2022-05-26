using System.ComponentModel;
using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Timesheet;

namespace Timesheet_Expenses_API.Repositories
{
    public interface ITimesheetRepository
    {
        public int GetUserId(string email);
        public WorklogCompleteInfo GetWorklog(int worklogId);
        public bool CreateWorklog(PostWorklogTimesheet worklog, int userId);
        public bool UpdateWorklog(PutWorklogTimesheet worklog);
        public bool DeleteWorklog(int worklogId);
        public List<ProjectsIdName> GetProjectUser(int userId);
        public List<ActivityIdName> GetActivityUser(int userId, int projectId);
        public List<TimesheetWorklog> GetUserWeekWorklog(DateTime date, int userId);
        public ActivityInfo GetActivitiesInfo(int activityId);
        public ProjectInfo GetProjectInfo(int projectId);
        public byte[] GetFile(int fileContId);
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

        //recebe um worklogId e devolve as informações sobre o mesmo indicado      
        public WorklogCompleteInfo GetWorklog(int worklogId)
        {
            try
            {
                var worklog = db.worklogs.Find(worklogId);
                WorklogCompleteInfo wlInfo = new WorklogCompleteInfo();
                wlInfo.ActivityName = db.activities.Find(worklog.ActivityId).Name;
                wlInfo.BillingType = db.billingTypes.Find(worklog.BillingTypeId).Type;
                wlInfo.WorklogState = db.worklogStates.Find(worklog.WorklogStateId).State;
                wlInfo.Hours = worklog.Hours;
                wlInfo.Comment = worklog.Comment;
                wlInfo.Date = worklog.Date;

                return wlInfo;
            }
            catch
            {
                return new WorklogCompleteInfo();
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
        public List<ActivityIdName> GetActivityUser(int userId, int projectId)
        {
            try
            {
                List<ActivityIdName> ActivityUsers = new List<ActivityIdName>();

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
                            ActivityIdName actUser = new ActivityIdName();
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
                return new List<ActivityIdName>();
            }
        }

        //recebe o id do user e devolve uma lista com o nome e id de todos os projetos ao qual está relacionado
        public List<ProjectsIdName> GetProjectUser(int userId)
        {
            try
            {
                //procura as equipas com o userId indicado
                var team = db.teams.Where(t => t.UserId.Equals(userId)).ToList();
                //cria e devolve a lista de projectos que se relacionam com o user
                List<ProjectsIdName> projectsInfo = new List<ProjectsIdName>();
                foreach (Team t in team)
                {
                    var proj = db.projects.Find(t.ProjectId);
                    var pInfo = new ProjectsIdName();
                    pInfo.projectId = proj.Project_Id;
                    pInfo.PorjectName = proj.Name;
                    projectsInfo.Add(pInfo);
                }

                return projectsInfo;
            }
            catch
            {
                return new List<ProjectsIdName>();
            }
        }

        //recebe a data indicada e devolve uma lista com todas as worklogs do user
        public List<TimesheetWorklog> GetUserWeekWorklog(DateTime date, int userId)
        {
            try
            {
                List<TimesheetWorklog> TimesheetWorklogs = new List<TimesheetWorklog>();

                //vai percorrer a semana toda e adicionar todas as worklogs da semana do user indicado a uma lista
                List<Worklog> worklog = new List<Worklog>();
                for (int i = 0; i < 7; i++)
                {
                    List<Worklog> worklogAux = db.worklogs.Where(wl => wl.User.User_Id.Equals(userId) && wl.Date.Equals(date.AddDays(i))).ToList();
                    foreach (Worklog w in worklogAux)
                    {
                        worklog.Add(w);
                    }
                }

                //todos os ids e nomes das diferentes atividades da worklog
                List<ActivityIdName> activitiesInfos = new List<ActivityIdName>();
                foreach (Worklog wl in worklog)
                {
                    bool aux = false;
                    foreach (ActivityIdName ai in activitiesInfos)
                    {
                        if (ai.ActivityId == wl.ActivityId)
                        {
                            aux = true;
                            break;
                        }
                    }
                    //caso o id da worklog ainda não esteja alucado na lista activitiesInfos vai criar um objeto ActivityInfo e adicionar o mesmo
                    if (aux == false)
                    {
                        ActivityIdName actInfo = new ActivityIdName();
                        actInfo.ActivityId = wl.ActivityId;
                        actInfo.ActivityName = db.activities.Find(wl.ActivityId).Name;
                        activitiesInfos.Add(actInfo);
                    }
                }

                //vai criar um objeto TimesheetWorklog e adicionar o mesmo à lista a que vamos dar return
                foreach (ActivityIdName ai in activitiesInfos)
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

        //recebe um id de uma atividade e devolve a informação da atividade, assim como uma lista de todos os ficheiros(nome e id, o proprio ficheiro não é enviado aqui) relacionados com essa atividade
        public ActivityInfo GetActivitiesInfo(int activityId)
        {
            try
            {
                //procura a Activity com o id recebido
                var activity = db.activities.Find(activityId);

                //cria um objeto do tipo ActivityInfo e preenche os campos do mesmo
                ActivityInfo activityInfos = new ActivityInfo();
                ActivityIdName actIdName = new ActivityIdName();
                actIdName.ActivityName = activity.Name;
                actIdName.ActivityId = activity.Activity_Id;
                activityInfos.ActivityIdName = actIdName;

                activityInfos.ActivityState = db.activityState.Find(activity.ActivityStateId).State;
                activityInfos.ActivityType = db.activityType.Find(activity.ActivityTypeId).Type;
                activityInfos.ActivityDescription = activity.Description;

                ProjectsIdName projIdName = new ProjectsIdName();
                projIdName.projectId = db.projects.Find(activity.ProjectId).Project_Id;
                projIdName.PorjectName = db.projects.Find(activity.ProjectId).Name;
                activityInfos.ProjectInfo = projIdName;

                //procura todos os registos em activities_file com o activityId indicado
                var actFile = db.activities_files.Where(af => af.ActivityId.Equals(activityId)).ToList();
                //preenche a infomação de cada file e adiciona o mesmo ao objeto do tipo ActivityInfo
                List<FileContInfo> fileContInfos = new List<FileContInfo>();
                foreach (Activity_File actF in actFile)
                {
                    var fileCont = db.fileContents.Find(actF.FileContentId);
                    FileContInfo fileContInfo = new FileContInfo();
                    fileContInfo.FileContId = fileCont.FileContent_Id;
                    fileContInfo.Name = fileCont.Name;
                    fileContInfos.Add(fileContInfo);
                }
                activityInfos.FileContInfo = fileContInfos;

                var comments = db.comments.Where(c => c.ActivityId.Equals(activityId)).ToList();
                List<CommentText> commentsText = new List<CommentText>();
                foreach (Comment c in comments)
                {
                    CommentText ct = new CommentText();
                    ct.Text = c.Text;
                    commentsText.Add(ct);
                }
                activityInfos.ActivityComments = commentsText;

                return activityInfos;
            }
            catch
            {
                return new ActivityInfo();
            }
        }

        //recebe o id do project indicado e devolve as informações do mesmo, tal como as equipas que têm algum tipo de relação com o mesmo
        public ProjectInfo GetProjectInfo(int projectId)
        {
            try
            {
                ProjectInfo projectInfo = new ProjectInfo();
                //encontra o Project com o projectId indicado
                var project = db.projects.Find(projectId);

                //adicionar o PorjectName e projectId do Project
                ProjectsIdName projectIdName = new ProjectsIdName();
                projectIdName.projectId = project.Project_Id;
                projectIdName.PorjectName = project.Name;
                projectInfo.ProjectsIdName = projectIdName;

                //cria uma lista de Activities que estão relacionadas ao Project
                var activitiesProj = db.activities.Where(a => a.ProjectId.Equals(projectId)).ToList();
                List<ActivityIdName> activities = new List<ActivityIdName>();
                foreach (Activity a in activitiesProj)
                {
                    ActivityIdName actIdName = new ActivityIdName();
                    actIdName.ActivityId = a.Activity_Id;
                    actIdName.ActivityName = a.Name;
                    activities.Add(actIdName);
                }
                projectInfo.ProjectActivities = activities;
                //adiciona ProjectState e StartDate e EndDate
                projectInfo.ProjectState = db.projectStates.Find(project.ProjectStateId).State;
                projectInfo.StartDate = project.StartDate;
                projectInfo.EndDate = project.EndDate;

                //adiciona as informações sobre o Client
                ClientEmailName client = new ClientEmailName();
                client.Email = db.client.Find(project.ClientId).Email;
                client.Name = db.client.Find(project.ClientId).Name;
                projectInfo.Client = client;

                //cria um objecto de TeamInfo e adiciona o mesmo a projectInfo
                var projectTeams = db.teams.Where(t => t.ProjectId.Equals(projectId)).ToList();
                List<TeamInfo> teams = new List<TeamInfo>();
                foreach (Team t in projectTeams)
                {
                    bool aux = false;
                    foreach (TeamInfo tf in teams)
                    {
                        if (tf.Name == t.TeamName)
                        {
                            aux = true;
                            break;
                        }
                    }
                    //vai criar um objeto do tipo TeamInfo caso o TeamName seja novo para a coleção teams
                    if (aux == false)
                    {
                        //adiciona ao objeto TeamInfo o TeamName
                        TeamInfo teamInfo = new TeamInfo();
                        teamInfo.Name = t.TeamName;
                        //procura todos os registos das teams com o Name igual e adiciona a uma List<Team>
                        var teamNames = db.teams.Where(ta => ta.TeamName.Equals(teamInfo.Name)).ToList();
                        List<TimesheetUserInfo> userInfos = new List<TimesheetUserInfo>();
                        foreach (Team tm in teamNames)
                        {
                            //para cada User dentro da Team vai adicionar as informações do mesmo
                            TimesheetUserInfo timesheetUserInfo = new TimesheetUserInfo();
                            timesheetUserInfo.Name = db.users.Find(tm.UserId).Name;
                            timesheetUserInfo.Email = db.users.Find(tm.UserId).Email;
                            timesheetUserInfo.Function = db.userFunction.Find(tm.UserFunctionId).Function;
                            userInfos.Add(timesheetUserInfo);
                        }
                        //adiciona a TimesheetUserInfo e por fim adiciona a teams o objecto teamInfo
                        teamInfo.UserInfo = userInfos;
                        teams.Add(teamInfo);
                    }
                }
                projectInfo.Teams = teams;

                return projectInfo;
            }
            catch
            {
                return new ProjectInfo();
            }
        }

        //recebe um fileContentId e devolve o ficheiro do mesmo
        public byte[] GetFile(int fileContId)
        {
            try
            {
                //procura o fileContent correspondente ao fileContId recebido
                var fileId = db.fileContents.Find(fileContId).FileId;
                return db.files.Find(fileId).base64;
            }
            catch
            {
                return new byte[0];
            }
        }
    }
}
