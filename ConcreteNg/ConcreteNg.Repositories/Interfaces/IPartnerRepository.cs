using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Interfaces
{
    public interface IPartnerRepository : IRepository<Partner>
    {
        IEnumerable<Partner> GetEmployerPartners(int employerId);
        TableResponse GetEmployerPartnersTable(TableRequest tableRequest, int employerId);
        
    }
}
