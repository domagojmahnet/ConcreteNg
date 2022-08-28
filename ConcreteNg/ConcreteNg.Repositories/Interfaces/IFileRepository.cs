using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = ConcreteNg.Shared.Models.File;

namespace ConcreteNg.Repositories.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
    }
}
