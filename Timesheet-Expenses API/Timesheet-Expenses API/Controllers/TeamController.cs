using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Team;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly ITeamRepository repos;

        public TeamController(ITeamRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("User_Id};{Project_Id}")]
        public IActionResult Get([FromRoute] TeamId team)
        {
            var team_db = repos.Read(team.userID, team.projectID);

            return Ok(team_db);
        }

        [HttpPost]
        public IActionResult Post(PostTeam team)
        {
            if (repos.Create(team))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutTeam team)
        {
            if (repos.Update(team))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{UserI_d};{Project_Id}")]
        public IActionResult Delete([FromRoute] TeamId team)
        {
            if (repos.Delete(team.userID, team.projectID))
                return Ok();

            return BadRequest();
        }
    }
}
