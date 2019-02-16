using Planner.DataAccess.Context;
using Planner.DataAccess.Interfaces.Repositories;
using Planner.DataAccess.PlannerAggregate;

namespace Planner.DataAccess.Concrete
{
    public class AssignmentRepository : EfRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(PlannerContext plannerContext) : base(plannerContext)
        {

        }
    }
}
