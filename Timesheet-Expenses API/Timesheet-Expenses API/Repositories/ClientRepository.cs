using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Client;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IClientRepository
    {
        public bool Create(PostClient client);
        public Client Read(int id);
        public bool Update(PutClient client);
        public bool Delete(int id);
    }

    public class ClientRepository:IClientRepository
    {
        private readonly _DbContext db;

        public ClientRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostClient client)
        {
            try
            {
                var client_db = new Client()
                {
                    Name = client.Name,
                    Email = client.Email
                };
                db.client.Add(client_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Client Read(int id)
        {
            try
            {
                var client_db = db.client.Find(id);

                return client_db;
            }
            catch
            {
                return new Client();
            }
        }

        public bool Update(PutClient client)
        {
            try
            {
                var client_db = db.client.Find(client.Client_Id);
                client_db.Name = client.Name;
                client_db.Email = client.Email;
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
                var client_db = db.client.Find(id);
                db.client.Remove(client_db);
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
