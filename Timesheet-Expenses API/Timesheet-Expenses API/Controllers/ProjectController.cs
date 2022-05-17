using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Project;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository repos;

        public ProjectController(IProjectRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Project_Id}")]
        public IActionResult Get([FromRoute] ProjectId project)
        {
            var project_db = repos.Read(project.Project_Id);

            return Ok(project_db);
        }

        [HttpPost]
        public IActionResult Post(PostProject project)
        {
            if (repos.Create(project))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutProject project)
        {
            if (repos.Update(project))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Project_Id}")]
        public IActionResult Delete([FromRoute] ProjectId project)
        {
            if (repos.Delete(project.Project_Id))
                return Ok();

            return BadRequest();
        }
    }
}
