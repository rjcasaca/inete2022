using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.UserFunction;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IUserFunctionRepository
    {
        public bool Create(PostUserFunction user);
        public UserFunction Read(int id);
        public bool Update(PutUserFunction user);
        public bool Delete(int id);
    }

    public class UserFunctionRepository:IUserFunctionRepository
    {
        private readonly _DbContext db;

        public UserFunctionRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostUserFunction userFunction)
        {
            try
            {
                var userFunction_db = new UserFunction()
                {
                    Function = userFunction.Function
                };
                db.userFunction.Add(userFunction_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public UserFunction Read(int id)
        {
            try
            {
                var userFunction_db = db.userFunction.Find(id);

                return userFunction_db;
            }
            catch
            {
                return new UserFunction();
            }
        }

        public bool Update(PutUserFunction userFunction)
        {
            try
            {
                var userFunction_db = db.userFunction.Find(userFunction.UserFunc_Id);
                userFunction_db.Function = userFunction.Function;
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
                var userFunction_db = db.userFunction.Find(id);
                db.userFunction.Remove(userFunction_db);
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
