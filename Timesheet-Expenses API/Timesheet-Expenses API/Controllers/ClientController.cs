using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Client;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository repos;

        public ClientController(IClientRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Client_Id}")]
        public IActionResult Get([FromRoute] ClientId client)
        {
            var client_db = repos.Read(client.Client_Id);

            return Ok(client_db);
        }

        [HttpPost]
        public IActionResult Post(PostClient client)
        {
            if (repos.Create(client))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutClient client)
        {
            if (repos.Update(client))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Client_Id}")]
        public IActionResult Delete([FromRoute] ClientId client)
        {
            if (repos.Delete(client.Client_Id))
                return Ok();

            return BadRequest();
        }
    }
}
