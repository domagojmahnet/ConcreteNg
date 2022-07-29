using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
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

        [HttpGet]
        [Route("pricingListItems")]
        public async Task<ActionResult<IEnumerable<PricingListItem>>> GetEmployerPricingListItems()
        {
            var items = employerService.GetEmployersPricingListItems();
            return Ok(items);
        }

        [HttpPost]
        [Route("pricingListItem")]
        public async Task<ActionResult> CreateOrUpdatePricingListItem([FromBody] PricingListItem item)
        {
            var result = employerService.CreateOrUpdatePricingListItem(item);
            return Ok();
        }

        [HttpDelete]
        [Route("pricingListItem/{id}")]
        public async Task<ActionResult> DeletePricingListItem(int id)
        {
            var result = employerService.DeletePricingListItem(id);
            return Ok();
        }
    }
}
