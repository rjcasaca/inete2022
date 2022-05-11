using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.User;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IUserRepository
    {
        public bool Create(PostUser user);
        public User Read(int id);
        public bool Update(PutUser user);
        public bool Delete(int id);
    }
    public class UserRepository:IUserRepository
    {
        private readonly _DbContext db;

        public UserRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostUser user)
        {
            try
            {
                var user_db = new User()
                {
                    Name = user.Name,
                    Email = user.Email
                };
                db.users.Add(user_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public User Read(int id)
        {
            try
            {
                var user_db = db.users.Find(id);
                
                return user_db;
            }
            catch
            {
                return new User();
            }
        }

        public bool Update(PutUser user)
        {
            try
            {
                var user_db = db.users.Find(user.User_Id);
                user_db.Name = user.Name;
                user_db.Email = user.Email;
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
                var user_db = db.users.Find(id);
                db.users.Remove(user_db);
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
