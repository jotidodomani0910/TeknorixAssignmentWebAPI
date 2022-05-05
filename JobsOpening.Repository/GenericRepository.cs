using JobsOpening.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobsOpening.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext context;
        internal DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this._logger = logger;

        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }


        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);

        }

        public virtual async Task<bool> Update(int id, T entity)
        {
            var entry = dbSet.Update(entity).Entity;
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();

        }

        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
