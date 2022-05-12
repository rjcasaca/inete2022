using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.FileContent;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileContentController : Controller
    {
        private readonly IFileContentRepository repos;

        public FileContentController(IFileContentRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{FileContent_Id}")]
        public IActionResult Get([FromRoute] FileContentId fileContent)
        {
            var fileContent_db = repos.Read(fileContent.FileContent_Id);

            return Ok(fileContent_db);
        }

        [HttpPost]
        public IActionResult Post(PostFileContent fileContent)
        {
            if (repos.Create(fileContent))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutFileContent fileContent)
        {
            if (repos.Update(fileContent))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{FileContent_Id}")]
        public IActionResult Delete([FromRoute] FileContentId fileContent)
        {
            if (repos.Delete(fileContent.FileContent_Id))
                return Ok();

            return BadRequest();
        }
    }
}
