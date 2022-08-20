using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Interfaces
{
    public interface IEmployerService
    {
        TableResponse GetEmployersPricingListItemsTable(TableRequest tableRequest);
        int CreateOrUpdatePricingListItem(PricingListItem item);
        IEnumerable<PricingListItem> GetEmployersPricingListItems();
        int DeletePricingListItem(int id);
        IEnumerable<Partner> GetEmployerPartners();
        TableResponse GetEmployerPartnersTable(TableRequest tableRequest);
        int AddEditPartner(Partner partner);
        int DeletePartner(int id);
    }
}
