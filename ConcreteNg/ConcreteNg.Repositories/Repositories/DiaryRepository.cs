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
    public class DiaryRepository : GenericRepository<DiaryItem>, IDiaryRepository
    {
        private readonly DataContext dataContext;
        public DiaryRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
        }
    }
}
