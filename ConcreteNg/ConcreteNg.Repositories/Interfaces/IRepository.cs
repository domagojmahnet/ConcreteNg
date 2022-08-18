using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        void Create(T entity);
        T Read(object keys);
        void Update(T entity);
        void Delete(T entity);
    }
}
