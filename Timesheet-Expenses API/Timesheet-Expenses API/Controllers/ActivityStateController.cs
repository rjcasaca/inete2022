using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.ActivityState;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityStateController : Controller
    {
        private readonly IActivityStateRepository repos;

        public ActivityStateController(IActivityStateRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{ActivityState_Id}")]
        public IActionResult Get([FromRoute] ActivityStateId activityState)
        {
            var ãctivityState_db = repos.Read(activityState.ActivityState_Id);

            return Ok(ãctivityState_db);
        }

        [HttpPost]
        public IActionResult Post(PostActivityState activityState)
        {
            if (repos.Create(activityState))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutActivityState activityState)
        {
            if (repos.Update(activityState))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{ActivityState_Id}")]
        public IActionResult Delete([FromRoute] ActivityStateId activityState)
        {
            if (repos.Delete(activityState.ActivityState_Id))
                return Ok();

            return BadRequest();
        }
    }
}
