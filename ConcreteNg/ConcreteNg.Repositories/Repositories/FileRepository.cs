using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = ConcreteNg.Shared.Models.File;

namespace ConcreteNg.Repositories.Repositories
{
    internal class FileRepository : GenericRepository<File>, IFileRepository
    {
        public FileRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
