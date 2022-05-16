using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Object.Timesheet;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : Controller
    {
        private readonly ITimesheetRepository repos;

        public TimesheetController(ITimesheetRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Email}")]
        public IActionResult GetUserId([FromRoute] TimesheetUserInfo user)
        {
            var user_db = repos.GetUserId(user.Email);

            return Ok(user_db);
        }

        [HttpGet("{Date}")]
        public IActionResult GetUserWorklog([FromRoute] DateTime date)
        {
            var worklog_db = repos.GetUserWorklog(date);

            return Ok(worklog_db);
        }

        [HttpPost]
        public IActionResult PostWorklog(PostWorklogTimesheet worklog)
        {
            if (repos.CreateWorklog(worklog))
                return Ok();

            return BadRequest();
        }

        [HttpGet("{activityId}")]
        public IActionResult GetActivityInfo([FromRoute] int activityId)
        {
            var activity_db = repos.GetActivityInfo(activityId);

            return Ok(activity_db);
        }

        [HttpGet("{projectId}")]
        public IActionResult GetProjectInfo([FromRoute] int projectId)
        {
            var project_db = repos.GetProjectInfo(projectId);

            return Ok(project_db);
        }
    }
}
