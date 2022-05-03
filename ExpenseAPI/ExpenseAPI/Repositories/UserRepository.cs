using ExpenseAPI.Models;
using ExpenseAPI.Models.Entites.User;

namespace ExpenseAPI.Repositories
{
    public interface IUserRepository
    {
        public bool Create(PostUser user);
        public User Read(string email);

        public bool Update(PutUser user);

        public bool Delete(string email);


    }
    public class UserRepository: IUserRepository
    {
        private readonly _DbContext db;
       public UserRepository(_DbContext _db)
        {
            db= _db;
        }
        public bool Create(PostUser user)
        {
            try
            {
                var user_db = new User()
                {
                    Email = user.Email,
                    Name = user.Name

                };
                db.user.Add(user_db);
                db.SaveChanges();

                return true;

            }catch(Exception ex) { return false; }
        
        }
        public User Read(string email)
        {
            try 
            {
                var user_db = db.user.Find(email);
                return user_db;
            }
            catch(Exception ex) 
            { return new User(); }
        }
        public bool Update(PutUser user)
        {
            try
            {
                var user_db= db.user.Find(user.email);
                user_db.Name= user.Name;
                user_db.Email= user.Email;
                db.SaveChanges();
                return true;
             }
            catch (Exception ex) { return false; }
        }
        public bool Delete(string email)
        {
            try
            {
                var user_db = db.user.Find(email);
                db.user.Remove(user_db);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

    }
}
