using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.ActivityType;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityTypeController : Controller
    {
        private readonly IActivityTypeRepository repos;

        public ActivityTypeController(IActivityTypeRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{ActivityType_Id}")]
        public IActionResult Get([FromRoute] ActivityTypeId activityType)
        {
            var activityType_db = repos.Read(activityType.ActivityType_Id);

            return Ok(activityType_db);
        }

        [HttpPost]
        public IActionResult Post(PostActivityType activityType)
        {
            if (repos.Create(activityType))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutActivityType activityType)
        {
            if (repos.Update(activityType))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{ActivityType_Id}")]
        public IActionResult Delete([FromRoute] ActivityTypeId activityType)
        {
            if (repos.Delete(activityType.ActivityType_Id))
                return Ok();

            return BadRequest();
        }
    }
}
