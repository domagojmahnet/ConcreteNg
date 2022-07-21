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
        PricingListItem AddPricingListItem(PricingListItem item);
    }
}
