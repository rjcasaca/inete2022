using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Project;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IProjectRepository
    {
        public bool Create(PostProject project);
        public Project Read(int id);
        public bool Update(PutProject project);
        public bool Delete(int id);
    }

    public class ProjectRepository: IProjectRepository
    {
        private readonly _DbContext db;

        public ProjectRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostProject project)
        {
            try
            {
                var project_db = new Project()
                {
                    Name = project.Name,
                    ProjectState = project.ProjectState,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Client = project.Client

                };
                db.projects.Add(project_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Project Read(int id)
        {
            try
            {
                var project_db = db.projects.Find(id);

                return project_db;
            }
            catch
            {
                return new Project();
            }
        }

        public bool Update(PutProject project)
        {
            try
            {
                var project_db = db.projects.Find(project.Project_Id);
                project_db.Name = project.Name;
                project_db.ProjectState = project.ProjectState;
                project_db.StartDate = project.StartDate;
                project_db.EndDate = project.EndDate;
                project_db.Client = project.Client;
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
                var project_db = db.projects.Find(id);
                db.projects.Remove(project_db);
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
