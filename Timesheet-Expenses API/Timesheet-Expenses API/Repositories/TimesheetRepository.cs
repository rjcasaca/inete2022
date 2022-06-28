using System.ComponentModel;
using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Timesheet;

namespace Timesheet_Expenses_API.Repositories
{
    public interface ITimesheetRepository
    {
        public int GetUserId(string email);
        public WorklogCompleteInfo GetWorklog(int worklogId);
        public bool CreateWorklog(DateTime date, decimal hours, string comment, int activity, string billingType, string worklogState, int userId);
        public bool CreateWorklogByPeriod(DateTime EndDate, DateTime StartDate, decimal hours, string comment, int activity, string billingType, string worklogState, int userId);
        public bool UpdateWorklog(int worklogId, decimal hours, string comment, string billingType, string worklogState);
        public bool DeleteWorklog(int worklogId);
        public List<ProjectsIdName> GetProjectUser(int userId);
        public List<ActivityIdName> GetActivityUser(int userId, int projectId);
        public List<TimesheetWorklog> GetUserWeekWorklog(DateTime date, int userId);
        public ActivityInfo GetActivitiesInfo(int activityId);
        public ProjectInfo GetProjectInfo(int projectId);
        public UserInfo GetUserInfo(int userId);
        public List<string> GetBillingTypes();
        public List<string> GetWorklogState();
        public Date AddDays(DateTime date, int AddDays);
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
                wlInfo.WorklogId = worklogId;
                wlInfo.ActivityName = db.activities.Find(worklog.ActivityId).Name;
                wlInfo.ActivityId = worklog.ActivityId;
                wlInfo.BillingType = db.billingTypes.Find(worklog.BillingTypeId).Type;
                wlInfo.WorklogState = db.worklogStates.Find(worklog.WorklogStateId).State;
                wlInfo.Hours = worklog.Hours;
                wlInfo.Comment = worklog.Comment;
                int day = worklog.Date.Day;
                int month = worklog.Date.Month;
                int year = worklog.Date.Year;
                wlInfo.Day = day;
                wlInfo.Month = month;
                wlInfo.Year = year;

                return wlInfo;
            }
            catch
            {
                return new WorklogCompleteInfo();
            }
        }

        //cria um objecto do tipo Worklog e adiciona os dados do mesmo à base de dados
        public bool CreateWorklog(DateTime date, decimal hours, string comment, int activity, string billingType, string worklogState, int userId)
        {
            try
            {
                //verifica se esta worklog existe
                var verifWL1 = db.worklogs.Where(wl => wl.Date.Equals(date) && wl.ActivityId.Equals(activity) && wl.UserId.Equals(userId)).ToList();
                if (verifWL1.Count() != 0)
                    throw new Exception("This worklog already exists!!");

                //verifica se neste dia o total de horas já excedeu as 24 horas
                var verifWL2 = db.worklogs.Where(wl => wl.Date.Equals(date) && wl.UserId.Equals(userId)).ToList();
                decimal dayHours = hours;
                foreach (Worklog wl in verifWL2)
                {
                    dayHours += wl.Hours;
                }
                if (dayHours > 24)
                {
                    throw new Exception("Excedeu as horas de um dia!");
                }

                //cria a worklog
                var worklog_db = new Worklog
                {
                    Date = date,
                    Hours = hours,
                    Comment = comment,
                    User = db.users.Find(userId),
                    Activity = db.activities.Find(activity),
                    WorklogState = db.worklogStates.Find(db.worklogStates.Where(ws => ws.State.Equals(worklogState)).FirstOrDefault().WorklogState_Id),
                    BillingType = db.billingTypes.Find(db.billingTypes.Where(bt => bt.Type.Equals(billingType)).FirstOrDefault().BillingType_Id)
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

        //cria um objecto do tipo Worklog para cada dia de entre duas datas e adiciona os dados do mesmo à base de dados
        public bool CreateWorklogByPeriod(DateTime EndDate, DateTime StartDate, decimal hours, string comment, int activity, string billingType, string worklogState, int userId)
        {
            try
            {
                //verifica se existe alguma workog no periodo escolhido
                DateTime DateAux = StartDate;
                while (DateAux != EndDate)
                {
                    var verifWL = db.worklogs.Where(wl => wl.Date.Equals(DateAux) && wl.ActivityId.Equals(activity) && wl.UserId.Equals(userId)).ToList();
                    if (verifWL.Count() != 0)
                        throw new Exception("This worklog already exists!!");

                    //verifica se neste dia o total de horas já excedeu as 24 horas
                    var verifWL2 = db.worklogs.Where(wl => wl.Date.Equals(DateAux) && wl.UserId.Equals(userId)).ToList();
                    decimal dayHours = hours;
                    foreach (Worklog wl in verifWL2)
                    {
                        dayHours += wl.Hours;
                    }
                    if (dayHours > 24)
                    {
                        throw new Exception("Excedeu as horas de um dia!");
                    }

                    DateAux = DateAux.AddDays(1);
                }

                while (StartDate != EndDate)
                {
                    // cria a worklog
                    var worklog_db = new Worklog
                    {
                        Date = StartDate,
                        Hours = hours,
                        Comment = comment,
                        User = db.users.Find(userId),
                        Activity = db.activities.Find(activity),
                        WorklogState = db.worklogStates.Find(db.worklogStates.Where(ws => ws.State.Equals(worklogState)).FirstOrDefault().WorklogState_Id),
                        BillingType = db.billingTypes.Find(db.billingTypes.Where(bt => bt.Type.Equals(billingType)).FirstOrDefault().BillingType_Id)
                    };
                    //adiciona à base de dados e salva as alterações
                    db.worklogs.Add(worklog_db);
                    db.SaveChanges();
                    //adiciono um dia à data inicial
                    StartDate = StartDate.AddDays(1);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //recebe os novos valores de uma worklog e atualiza os mesmos
        public bool UpdateWorklog(int worklogId, decimal hours, string comment, string billingType, string worklogState)
        {
            try
            {
                //procura o registo com o id indicado
                var worklog_db = db.worklogs.Find(worklogId);
                //atualiza os dados igualando os mesmos
                worklog_db.Hours = hours;
                worklog_db.Comment = comment;
                worklog_db.WorklogState = db.worklogStates.Find(db.worklogStates.Where(ws => ws.State.Equals(worklogState)).FirstOrDefault().WorklogState_Id);
                worklog_db.BillingType = db.billingTypes.Find(db.billingTypes.Where(bt => bt.Type.Equals(billingType)).FirstOrDefault().BillingType_Id);
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
                            if (a.ActivityStateId != 2)
                            {
                                ActivityIdName actUser = new ActivityIdName();
                                actUser.ActivityId = a.Activity_Id;
                                actUser.ActivityName = a.Name;
                                ActivityUsers.Add(actUser);
                            }
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
                    if (proj.ProjectStateId == 1)
                    {
                        var pInfo = new ProjectsIdName();
                        pInfo.projectId = proj.Project_Id;
                        pInfo.projectName = proj.Name;
                        projectsInfo.Add(pInfo);
                    }
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
                    TimesheetWorklog tw = new TimesheetWorklog();
                    tw.Activity = ai;
                    foreach (Worklog wl in worklog)
                    {
                        if (ai.ActivityId == wl.ActivityId)
                        {
                            WorklogInfo wli = new WorklogInfo();
                            wli.worklogId = wl.Cod_Worklog;
                            wli.Hours = wl.Hours;
                            //ver o dia da semana
                            switch (wl.Date.DayOfWeek)
                            {
                                case DayOfWeek.Monday:
                                    tw.Monday = wli;
                                    break;
                                case DayOfWeek.Tuesday:
                                    tw.Tuesday = wli;
                                    break;
                                case DayOfWeek.Wednesday:
                                    tw.Wednesday = wli;
                                    break;
                                case DayOfWeek.Thursday:
                                    tw.Thursday = wli;
                                    break;
                                case DayOfWeek.Friday:
                                    tw.Friday = wli;
                                    break;
                                case DayOfWeek.Saturday:
                                    tw.Saturday = wli;
                                    break;
                                case DayOfWeek.Sunday:
                                    tw.Sunday = wli;
                                    break;
                            }
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
                projIdName.projectName = db.projects.Find(activity.ProjectId).Name;
                activityInfos.ProjectInfo = projIdName;

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
                projectIdName.projectName = project.Name;
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
                projectInfo.StartDay = project.StartDate.Day;
                projectInfo.StartMonth = project.StartDate.Month;
                projectInfo.StartYear = project.StartDate.Year;
                projectInfo.EndDay = project.EndDate.Day;
                projectInfo.EndMonth = project.EndDate.Month;
                projectInfo.EndYear = project.EndDate.Year;

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
                            timesheetUserInfo.UserId = db.users.Find(tm.UserId).User_Id;
                            timesheetUserInfo.UserName = db.users.Find(tm.UserId).Name;
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

        //retorna todos os billing types
        public List<string> GetBillingTypes()
        {
            try
            {
                List<string> BillingTypes = new List<string>();
                var BillingTypesObj = db.billingTypes.ToList();
                foreach (BillingType bt in BillingTypesObj)
                {
                    BillingTypes.Add(bt.Type);
                }

                return BillingTypes;
            }
            catch
            {
                return new List<string>();
            }
        }

        //retorna todos os worklog states
        public List<string> GetWorklogState()
        {
            try
            {
                List<string> WorklogState = new List<string>();
                var WorklogStateObj = db.worklogStates.ToList();
                foreach (WorklogState bt in WorklogStateObj)
                {
                    WorklogState.Add(bt.State);
                }

                return WorklogState;
            }
            catch
            {
                return new List<string>();
            }
        }

        //adiciona o numero de dias referidos na data recebida, retorna a segunda feira da data já com os dias adicionados
        public Date AddDays(DateTime date, int AddDays)
        {
            try
            {
                Date mondayDate = new Date();

                date = date.AddDays(AddDays);
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        mondayDate.Day = date.Day;
                        mondayDate.Month = date.Month;
                        mondayDate.Year = date.Year;
                        break;
                    case DayOfWeek.Tuesday:
                        date = date.AddDays(-1);
                        mondayDate.Day = date.Day;
                        mondayDate.Month = date.Month;
                        mondayDate.Year = date.Year;
                        break;
                    case DayOfWeek.Wednesday:
                        date = date.AddDays(-2);
                        mondayDate.Day = date.Day;
                        mondayDate.Month = date.Month;
                        mondayDate.Year = date.Year;
                        break;
                    case DayOfWeek.Thursday:
                        date = date.AddDays(-3);
                        mondayDate.Day = date.Day;
                        mondayDate.Month = date.Month;
                        mondayDate.Year = date.Year;
                        break;
                    case DayOfWeek.Friday:
                        date = date.AddDays(-4);
                        mondayDate.Day = date.Day;
                        mondayDate.Month = date.Month;
                        mondayDate.Year = date.Year;
                        break;
                    case DayOfWeek.Saturday:
                        date = date.AddDays(-5);
                        mondayDate.Day = date.Day;
                        mondayDate.Month = date.Month;
                        mondayDate.Year = date.Year;
                        break;
                    case DayOfWeek.Sunday:
                        date = date.AddDays(-6);
                        mondayDate.Day = date.Day;
                        mondayDate.Month = date.Month;
                        mondayDate.Year = date.Year;
                        break;
                }

                return mondayDate;
            }
            catch
            {
                return new Date();
            }
        }

        //retorna a informação de um user
        public UserInfo GetUserInfo(int userId)
        {
            try
            {
                UserInfo userInf = new UserInfo();
                userInf.UserName = db.users.Find(userId).Name;
                userInf.UserEmail = db.users.Find(userId).Email;

                return userInf;
            }
            catch
            {
                return new UserInfo();
            }
        }
    }
}
