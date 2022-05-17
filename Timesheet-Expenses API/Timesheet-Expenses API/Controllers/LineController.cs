using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Line;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LineController : Controller
    {
        private readonly ILineRepository repos;

        public LineController(ILineRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Cod_Line}")]
        public IActionResult Get([FromRoute] LineId line)
        {
            var line_db = repos.Read(line.Cod_Line);

            return Ok(line_db);
        }

        [HttpPost]
        public IActionResult Post(PostLine line)
        {
            if (repos.Create(line))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutLine line)
        {
            if (repos.Update(line))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Cod_Line}")]
        public IActionResult Delete([FromRoute] LineId line)
        {
            if (repos.Delete(line.Cod_Line))
                return Ok();

            return BadRequest();
        }
    }
}
