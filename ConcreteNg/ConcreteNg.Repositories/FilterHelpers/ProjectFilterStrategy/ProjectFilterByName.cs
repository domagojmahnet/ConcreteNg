using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.FilterHelpers.ProjectFilterStrategy
{
    public class ProjectFilterByName : IProjectFilterStrategy
    {
        public IQueryable<Project> Filter(IQueryable<Project> query, string filterQuery)
        {
            return query.Where(x => x.Name.Contains(filterQuery));
        }
    }
}
