using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Repositories.TableRequestHelpers;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    internal class PartnerRepository : GenericRepository<Partner>, IPartnerRepository
    {
        private readonly DataContext dataContext;
        public PartnerRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
        }

        public IEnumerable<Partner> GetEmployerPartners(int employerId)
        {
            return dataContext.Partners.Where(x => x.Employer.EmployerId == employerId);
        }

        public TableResponse GetEmployerPartnersTable(TableRequest tableRequest, int employerId)
        {
            TableResponse tableResponse = new TableResponse();

            var query = dataContext.Partners.Where(x => x.Employer.EmployerId == employerId);
            tableResponse.TotalRows = query.Count();

            IFilterTemplate<Partner> filterTemplate = FilterFactory<Partner>.CreateSortingObject();
            tableResponse.Data = filterTemplate.GetData(query, tableRequest);

            return tableResponse;
        }
    }
}
