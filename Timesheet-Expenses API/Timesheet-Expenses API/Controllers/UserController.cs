using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.User;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository repos;

        public UserController(IUserRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{User_Id}")]
        public IActionResult Get([FromRoute]UserId user)
        {
            var user_db = repos.Read(user.User_Id);

            return Ok(user_db);
        }

        [HttpPost]
        public IActionResult Post(PostUser user)
        {
            if (repos.Create(user))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutUser user)
        {
            if (repos.Update(user))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{User_Id}")]
        public IActionResult Delete([FromRoute] UserId user)
        {
            if (repos.Delete(user.User_Id))
                return Ok();

            return BadRequest();
        }
    }
}
