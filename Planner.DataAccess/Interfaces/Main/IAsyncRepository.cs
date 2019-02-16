using Planner.DataAccess.PlannerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planner.DataAccess.Interfaces.Main
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeletePermanentlyAsync(int id);
    }
}
