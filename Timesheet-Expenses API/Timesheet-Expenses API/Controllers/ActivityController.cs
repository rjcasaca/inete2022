using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Activity;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IActivityRepository repos;

        public ActivityController(IActivityRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Activity_Id}")]
        public IActionResult Get([FromRoute] ActivityId activity)
        {
            var activity_db = repos.Read(activity.Activity_Id);

            return Ok(activity_db);
        }

        [HttpPost]
        public IActionResult Post(PostActivity activity)
        {
            if (repos.Create(activity))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutActivity activity)
        {
            if (repos.Update(activity))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Activity_Id}")]
        public IActionResult Delete([FromRoute] ActivityId activity)
        {
            if (repos.Delete(activity.Activity_Id))
                return Ok();

            return BadRequest();
        }
    }
}
