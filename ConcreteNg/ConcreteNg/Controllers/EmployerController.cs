using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteNg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService employerService;

        public EmployerController(IEmployerService _employerService)
        {
            employerService = _employerService;
        }

        [HttpPost]
        [Route("pricingListItems/table")]
        public async Task<ActionResult<IEnumerable<PricingListItem>>> GetEmployerPricingListItemsTable([FromBody] TableRequest tableRequest)
        {
            var items = employerService.GetEmployersPricingListItemsTable(tableRequest);
            return Ok(items);
        }
    }
}
