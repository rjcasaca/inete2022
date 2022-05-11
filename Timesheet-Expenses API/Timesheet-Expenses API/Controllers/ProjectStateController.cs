using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.ProjectState;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStateController : Controller
    {
        private readonly IProjectStateRepository repos;

        public ProjectStateController(IProjectStateRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{ProjState_Id}")]
        public IActionResult Get([FromRoute] ProjectStateId projectState)
        {
            var projectState_db = repos.Read(projectState.ProjState_Id);

            return Ok(projectState_db);
        }

        [HttpPost]
        public IActionResult Post(PostProjectState projectState)
        {
            if (repos.Create(projectState))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutProjectState projectState)
        {
            if (repos.Update(projectState))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{ProjState_Id}")]
        public IActionResult Delete([FromRoute] ProjectStateId projectState)
        {
            if (repos.Delete(projectState.ProjState_Id))
                return Ok();

            return BadRequest();
        }
    }
}
