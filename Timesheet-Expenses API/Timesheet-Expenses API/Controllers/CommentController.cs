using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Comment;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository repos;

        public CommentController(ICommentRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Comment_Id}")]
        public IActionResult Get([FromRoute] CommentId comment)
        {
            var comment_db = repos.Read(comment.Comment_Id);

            return Ok(comment_db);
        }

        [HttpPost]
        public IActionResult Post(PostComment comment)
        {
            if (repos.Create(comment))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutComment comment)
        {
            if (repos.Update(comment))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Comment_Id}")]
        public IActionResult Delete([FromRoute] CommentId comment)
        {
            if (repos.Delete(comment.Comment_Id))
                return Ok();

            return BadRequest();
        }
    }
}
