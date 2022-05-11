using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.BillingType;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IBillingTypeRepository
    {
        public bool Create(PostBillingType billingType);
        public BillingType Read(int id);
        public bool Update(PutBillingType billingType);
        public bool Delete(int id);
    }

    public class BillingTypeRepository:IBillingTypeRepository
    {
        private readonly _DbContext db;

        public BillingTypeRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostBillingType billingType)
        {
            try
            {
                var billingType_db = new BillingType()
                {
                    Type = billingType.Type,
                };
                db.billingTypes.Add(billingType_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public BillingType Read(int id)
        {
            try
            {
                var billigType_db = db.billingTypes.Find(id);

                return billigType_db;
            }
            catch
            {
                return new BillingType();
            }
        }

        public bool Update(PutBillingType billingType)
        {
            try
            {
                var billingType_db = db.billingTypes.Find(billingType.BillingType_Id);
                billingType_db.Type = billingType.Type;
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
                var billingType_db = db.billingTypes.Find(id);
                db.billingTypes.Remove(billingType_db);
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
