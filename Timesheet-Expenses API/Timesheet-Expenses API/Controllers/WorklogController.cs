using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Worklog;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorklogController : Controller
    {
        private readonly IWorklogRepository repos;

        public WorklogController(IWorklogRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Cod_Worklog}")]
        public IActionResult Get([FromRoute] WorklogId worklog)
        {
            var worklog_db = repos.Read(worklog.Cod_Worklog);

            return Ok(worklog_db);
        }

        [HttpPost]
        public IActionResult Post(PostWorklog worklog)
        {
            if (repos.Create(worklog))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutWorklog worklog)
        {
            if (repos.Update(worklog))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Cod_Worklog}")]
        public IActionResult Delete([FromRoute] WorklogId worklog)
        {
            if (repos.Delete(worklog.Cod_Worklog))
                return Ok();

            return BadRequest();
        }
    }
}
