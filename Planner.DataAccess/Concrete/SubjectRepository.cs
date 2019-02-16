using Planner.DataAccess.Context;
using Planner.DataAccess.Interfaces.Repositories;
using Planner.DataAccess.PlannerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.DataAccess.Concrete
{
    public class SubjectRepository : EfRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(PlannerContext plannerContext) : base(plannerContext)
        {

        }
    }
}
