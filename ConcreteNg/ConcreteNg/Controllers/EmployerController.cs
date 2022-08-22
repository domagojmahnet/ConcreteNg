using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Enums;
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

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpPost]
        [Route("pricingListItems/table")]
        public async Task<ActionResult<IEnumerable<PricingListItem>>> GetEmployerPricingListItemsTable([FromBody] TableRequest tableRequest)
        {
            var items = employerService.GetEmployersPricingListItemsTable(tableRequest);
            return Ok(items);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpGet]
        [Route("pricingListItems")]
        public async Task<ActionResult<IEnumerable<PricingListItem>>> GetEmployerPricingListItems()
        {
            var items = employerService.GetEmployersPricingListItems();
            return Ok(items);
        }

        [AuthorizeRoles(UserTypeEnum.Administrator)]
        [HttpPost]
        [Route("pricingListItem")]
        public async Task<ActionResult> CreateOrUpdatePricingListItem([FromBody] PricingListItem item)
        {
            var result = employerService.CreateOrUpdatePricingListItem(item);
            return Ok();
        }

        [AuthorizeRoles(UserTypeEnum.Administrator)]
        [HttpDelete]
        [Route("pricingListItem/{id}")]
        public async Task<ActionResult> DeletePricingListItem(int id)
        {
            var result = employerService.DeletePricingListItem(id);
            return Ok();
        }

        [AuthorizeRoles(UserTypeEnum.Administrator)]
        [HttpDelete]
        [Route("partner/{id}")]
        public async Task<ActionResult> DeletePartner(int id)
        {
            var result = employerService.DeletePartner(id);
            return Ok();
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpGet]
        [Route("partners")]
        public async Task<ActionResult<IEnumerable<PricingListItem>>> GetEmployerPartners()
        {
            var items = employerService.GetEmployerPartners();
            return Ok(items);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpPost]
        [Route("partners")]
        public async Task<ActionResult<TableResponse>> GetEmployerPartnersTable([FromBody] TableRequest tableRequest)
        {
            var items = employerService.GetEmployerPartnersTable(tableRequest);
            return Ok(items);
        }

        [AuthorizeRoles(UserTypeEnum.Administrator)]
        [HttpPost]
        [Route("partner")]
        public async Task<ActionResult<int>> AddEditPartner([FromBody] Partner partner)
        {
            var result = employerService.AddEditPartner(partner);
            return Ok(result);
        }
    }
}
