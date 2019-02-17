using Planner.DataAccess.Interfaces.Main;
using Planner.DataAccess.PlannerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Planner.DataAccess.Interfaces.Repositories
{
    public interface ISubjectRepository : IRepository<Subject>, IAsyncRepository<Subject>
    {
        List<Subject> GetAllListWithoutDeleted();
        List<Subject> GetAllListWithoutDeleted(Expression<Func<Subject, bool>> predicate);
    }
}
