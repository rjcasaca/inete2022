using Timesheet_API.Models;
using Timesheet_API.Models.Entities.Users;

namespace Timesheet_API.Repositories
{
    public interface IUsersRepository
    {
        public bool Create(PostUsers user);
        public User Read(string email);
        public bool Update(PutUsers user);
        public bool Delete(string email);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly _DbContext db;

        public UsersRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostUsers user)
        {
            try
            {
                var user_db = new User()
                {
                    email = user.email,
                    name = user.name
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

        public User Read(string email)
        {
            try
            {
                var user_db = db.users.Find(email);
                return user_db;
            }
            catch
            {
                return new User();
            }
        }

        public bool Update(PutUsers user)
        {
            try
            {
                var user_db = db.users.Find(user.email);
                user_db.email = user.email;
                user_db.name = user.name;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string email)
        {
            try
            {
                var user_db = db.users.Find(email);
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
