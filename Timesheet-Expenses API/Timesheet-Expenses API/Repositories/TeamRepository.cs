using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Team;

namespace Timesheet_Expenses_API.Repositories
{
    public interface ITeamRepository
    {
        public bool Create(PostTeam team);
        public Team Read(int uid, int pid);
        public bool Update(PutTeam team);
        public bool Delete(int uid, int pid);
    }

    public class TeamRepository:ITeamRepository
    {
        private readonly _DbContext db;

        public TeamRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostTeam team)
        {
            try
            {
                var team_db = new Team()
                {
                    TeamName = team.TeamName,
                    project = team.project,
                    user = team.user,
                    UserFunction = team.UserFunction
                };
                db.teams.Add(team_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Team Read(int uid, int pid)
        {
            try
            {
                var team_db = db.teams.Find(uid, pid);

                return team_db;
            }
            catch
            {
                return new Team();
            }
        }

        public bool Update(PutTeam team)
        {
            try
            {
                var team_db = db.teams.Find(team.UserId, team.ProjectId);
                team_db.TeamName = team.TeamName;
                team_db.project = team.project;
                team_db.user = team.user;
                team_db.UserFunction = team.UserFunction;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int uid, int pid)
        {
            try
            {
                var team_db = db.teams.Find(uid, pid);
                db.teams.Remove(team_db);
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
