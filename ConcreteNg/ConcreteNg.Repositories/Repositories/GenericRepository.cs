using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T>
    where T : class
    {
        private readonly DataContext dataContext;

        public GenericRepository(DataContext dbContext)
        {
            dataContext = dbContext;
        }

        public virtual IQueryable<T> List()
        {
            return dataContext.Set<T>();
        }

        public virtual void Create(T entity)
        {
            dataContext.Set<T>().Add(entity);
        }

        public virtual T Read(object keys)
        {
            return dataContext.Set<T>().Find(keys);
        }

        public virtual void Update(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dataContext.Set<T>().Remove(entity);
        }
    }
}
