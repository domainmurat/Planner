using Planner.DataAccess.Context;
using Planner.DataAccess.Interfaces.Main;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planner.DataAccess.Concrete
{
    public abstract class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public EfRepository(PlannerContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).SingleOrDefaultAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            else
            {
                entity.Deleted = true;
                this.Update(entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return;
            else
            {
                entity.Deleted = true;
                await UpdateAsync(entity);
            }
        }

        public void DeletePermanently(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            else
            {
                DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                    _dbContext.SaveChanges();
                }
            }
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return;
            else
            {
                DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }

                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IList<T> GetAllList()
        {
            return _dbSet.ToList();
        }

        public IList<T> GetAllList(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
    }
}
