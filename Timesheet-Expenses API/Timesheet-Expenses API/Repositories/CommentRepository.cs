using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Comment;

namespace Timesheet_Expenses_API.Repositories
{
    public interface ICommentRepository
    {
        public bool Create(PostComment comment);
        public Comment Read(int id);
        public bool Update(PutComment comment);
        public bool Delete(int id);
    }

    public class CommentRepository:ICommentRepository
    {
        private readonly _DbContext db;

        public CommentRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostComment comment)
        {
            try
            {
                var comment_db = new Comment()
                {
                    Text = comment.Text,
                    Activity = comment.Activity
                };
                db.comments.Add(comment_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Comment Read(int id)
        {
            try
            {
                var comment_db = db.comments.Find(id);

                return comment_db;
            }
            catch
            {
                return new Comment();
            }
        }

        public bool Update(PutComment comment)
        {
            try
            {
                var comment_db = db.comments.Find(comment.Comment_Id);
                comment_db.Text = comment.Text;
                comment_db.Activity = comment.Activity;
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
                var comment_db = db.comments.Find(id);
                db.comments.Remove(comment_db);
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
