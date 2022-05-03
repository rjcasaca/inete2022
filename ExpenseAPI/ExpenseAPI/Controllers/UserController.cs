using ExpenseAPI.Models.Entites.User;
using ExpenseAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repos;
        public UserController(IUserRepository _repos)
        {
            repos= _repos;  
        }
        
        
        [HttpGet("{Email}")]
        public IActionResult Get([FromRoute] UserID User) 
        {
            var user= repos.Read(User.email);

        return Ok(user);
        
        }
        [HttpPost]
        public IActionResult Post(PostUser user) 
        { 
            if(repos.Create(user))
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
        [HttpDelete("{Email}")]
        public IActionResult Delete([FromRoute]UserID user) 
        {
            if (repos.Delete(user.email))
                return Ok();

            return BadRequest();

        }

    }
}
