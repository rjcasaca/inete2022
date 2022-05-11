using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.ProjectState;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IProjectStateRepository
    {
        public bool Create(PostProjectState projectState);
        public ProjectState Read(int id);
        public bool Update(PutProjectState projectState);
        public bool Delete(int id);
    }

    public class ProjectStateRepository:IProjectStateRepository
    {
        private readonly _DbContext db;

        public ProjectStateRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostProjectState projectState)
        {
            try
            {
                var projectState_db = new ProjectState()
                {
                    State = projectState.State
                };
                db.projectStates.Add(projectState_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ProjectState Read(int id)
        {
            try
            {
                var projectState_db = db.projectStates.Find(id);

                return projectState_db;
            }
            catch
            {
                return new ProjectState();
            }
        }

        public bool Update(PutProjectState projectState)
        {
            try
            {
                var projectState_db = db.projectStates.Find(projectState.ProjState_Id);
                projectState_db.State = projectState.State;
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
                var projectState_db = db.projectStates.Find(id);
                db.projectStates.Remove(projectState_db);
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
