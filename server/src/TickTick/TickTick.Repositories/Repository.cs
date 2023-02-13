using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TickTick.Data;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TickTickDbContext _dbContext;
        private readonly DbSet<T> _modelDbSet;

        public Repository(TickTickDbContext ctx)
        {
            _dbContext = ctx ?? throw new ArgumentNullException();
            _modelDbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _modelDbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            Update(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _modelDbSet;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _modelDbSet.Where(predicate).ToListAsync();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _modelDbSet.Where(predicate).FirstOrDefaultAsync();
        }

        /*public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }*/

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _modelDbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
