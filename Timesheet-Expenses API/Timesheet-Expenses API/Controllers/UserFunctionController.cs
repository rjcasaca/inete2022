using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.UserFunction;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFunctionController : Controller
    {
        private readonly IUserFunctionRepository repos;

        public UserFunctionController(IUserFunctionRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{UserFunc_Id}")]
        public IActionResult Get([FromRoute] UserFunctionId userFunction)
        {
            var userFunction_db = repos.Read(userFunction.UserFunc_Id);

            return Ok(userFunction_db);
        }

        [HttpPost]
        public IActionResult Post(PostUserFunction userFunction)
        {
            if (repos.Create(userFunction))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutUserFunction userFunction)
        {
            if (repos.Update(userFunction))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{UserFunc_Id}")]
        public IActionResult Delete([FromRoute] UserFunctionId userFunction)
        {
            if (repos.Delete(userFunction.UserFunc_Id))
                return Ok();

            return BadRequest();
        }
    }
}
