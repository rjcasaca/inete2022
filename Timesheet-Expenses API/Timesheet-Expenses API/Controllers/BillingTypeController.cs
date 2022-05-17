using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.BillingType;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BillingTypeController : Controller
    {
        private readonly IBillingTypeRepository repos;

        public BillingTypeController(IBillingTypeRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{BillingType_Id}")]
        public IActionResult Get([FromRoute] BillingTypeId billingType)
        {
            var billingType_db = repos.Read(billingType.BillingType_Id);

            return Ok(billingType_db);
        }

        [HttpPost]
        public IActionResult Post(PostBillingType billingType)
        {
            if (repos.Create(billingType))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutBillingType billingType)
        {
            if (repos.Update(billingType))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{BillingType_Id}")]
        public IActionResult Delete([FromRoute] BillingTypeId billingType)
        {
            if (repos.Delete(billingType.BillingType_Id))
                return Ok();

            return BadRequest();
        }
    }
}
