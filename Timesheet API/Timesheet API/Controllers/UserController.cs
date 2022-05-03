using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_API.Models.Entities.Users;
using Timesheet_API.Repositories;

namespace Timesheet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository repos;

        public UserController(IUsersRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{email}")]
        public IActionResult Get([FromRoute] UserEmail user)
        {
            var user_db = repos.Read(user.email);
            return Ok(user_db);
        }

        [HttpPost]
        public IActionResult Post(PostUsers user)
        {
            if (repos.Create(user))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(PutUsers user)
        {
            if (repos.Update(user))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{email}")]
        public IActionResult Delete([FromRoute] UserEmail user) 
        {
            if (repos.Delete(user.email))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
