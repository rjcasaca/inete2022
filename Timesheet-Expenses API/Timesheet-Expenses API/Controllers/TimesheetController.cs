using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Object.Timesheet;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TimesheetController : Controller
    {
        private readonly ITimesheetRepository repos;

        public TimesheetController(ITimesheetRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Email}")]
        public IActionResult GetUserId([FromRoute] TimesheetUserInfo userInfo)
        {
            var uId_db = repos.GetUserId(userInfo.Email);
            return Ok(uId_db);
        }

        [HttpGet("{userId}")]
        public IActionResult GetProjectUser([FromRoute] int userId)
        {
            var projects_db = repos.GetProjectUser(userId);
            return Ok(projects_db);
        }

        [HttpGet("{userId};{projectId}")]
        public IActionResult GetActivityUser([FromRoute] int userId, int projectId)
        {
            var ActivityUser_db = repos.GetActivityUser(userId, projectId);
            return Ok(ActivityUser_db);
        }

        [HttpGet("{date};{userId}")]
        public IActionResult GetUserWorklog([FromRoute] DateTime date, int userId)
        {
            var worklog_db = repos.GetUserWorklog(date, userId);
            return Ok(worklog_db);
        }

        [HttpPost]
        public IActionResult PostWorklog(PostWorklogTimesheet worklog, int userId)
        {
            if (repos.CreateWorklog(worklog, userId))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateWorklog(PutWorklogTimesheet worklog)
        {
            if (repos.UpdateWorklog(worklog))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{worklog}")]
        public IActionResult DeleteWorklog([FromRoute] int worklog)
        {
            if (repos.DeleteWorklog(worklog))
                return Ok();

            return BadRequest();
        }
    }
}
