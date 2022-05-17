using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.FileContentType;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileContentTypeController : Controller
    {
        private readonly IFileContentTypeRepository repos;

        public FileContentTypeController(IFileContentTypeRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{FileContentType_Id}")]
        public IActionResult Get([FromRoute] FileContentTypeId fileContentType)
        {
            var fileContentType_db = repos.Read(fileContentType.FileContentType_Id);

            return Ok(fileContentType_db);
        }

        [HttpPost]
        public IActionResult Post(PostFileContentType fileContentType)
        {
            if (repos.Create(fileContentType))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutFileContentType fileContentType)
        {
            if (repos.Update(fileContentType))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{FileContentType_Id}")]
        public IActionResult Delete([FromRoute] FileContentTypeId fileContentType)
        {
            if (repos.Delete(fileContentType.FileContentType_Id))
                return Ok();

            return BadRequest();
        }
    }
}
