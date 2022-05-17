using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.File;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IFileRepository repos;

        public FileController(IFileRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{File_Id}")]
        public IActionResult Get([FromRoute] FileId file)
        {
            var file_db = repos.Read(file.File_Id);

            return Ok(file_db);
        }

        [HttpPost]
        public IActionResult Post(PostFile file)
        {
            if (repos.Create(file))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutFile file)
        {
            if (repos.Update(file))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{File_Id}")]
        public IActionResult Delete([FromRoute] FileId file)
        {
            if (repos.Delete(file.File_Id))
                return Ok();

            return BadRequest();
        }
    }
}
