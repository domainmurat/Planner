using Planner.DataAccess.Context;
using Planner.DataAccess.Interfaces.Repositories;
using Planner.DataAccess.PlannerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Planner.DataAccess.Concrete
{
    public class SubjectRepository : EfRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(PlannerContext plannerContext) : base(plannerContext)
        {

        }
        public override IList<Subject> GetAllList(Expression<Func<Subject, bool>> predicate)
        {
            return _dbSet.Include(s => s.ParentSubject).Include(s => s.User).Where(predicate).ToList();
        }
        public override IList<Subject> GetAllList()
        {
            return _dbSet.Include(s => s.ParentSubject).Include(s => s.User).ToList();
        }

        public List<Subject> GetAllListWithoutDeleted()
        {
            return _dbSet.Include(s => s.ParentSubject).Include(s => s.User).Where(x => !x.Deleted).ToList();
        }

        public List<Subject> GetAllListWithoutDeleted(Expression<Func<Subject, bool>> predicate)
        {
            return _dbSet.Include(s => s.ParentSubject).Include(s => s.User).Where(x => !x.Deleted).Where(predicate).ToList();
        }
    }
}
