using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.WorklogState;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorklogStateController : Controller
    {
        private readonly IWorklogStateRepository repos;

        public WorklogStateController(IWorklogStateRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{WorklogState_Id}")]
        public IActionResult Get([FromRoute] WorklogStateId worklogState)
        {
            var worklogState_db = repos.Read(worklogState.WorklogState_Id);

            return Ok(worklogState_db);
        }

        [HttpPost]
        public IActionResult Post(PostWorklogState worklogState)
        {
            if (repos.Create(worklogState))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutWorklogState worklogState)
        {
            if (repos.Update(worklogState))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{WorklogState_Id}")]
        public IActionResult Delete([FromRoute] WorklogStateId worklogState)
        {
            if (repos.Delete(worklogState.WorklogState_Id))
                return Ok();

            return BadRequest();
        }
    }
}
