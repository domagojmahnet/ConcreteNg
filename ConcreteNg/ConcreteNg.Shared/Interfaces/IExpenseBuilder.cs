using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Interfaces
{
    public interface IExpenseBuilder
    {
        ExpenseBuilder SetQuantity(float quantity);
        ExpenseBuilder SetPartner(Partner partner);
        ExpenseBuilder SetProjectTaskItem(ProjectTaskItem projectTaskItem);
    }
}
