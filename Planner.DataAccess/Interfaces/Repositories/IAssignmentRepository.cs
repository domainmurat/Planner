using Planner.DataAccess.Interfaces.Main;
using Planner.DataAccess.PlannerAggregate;
using System.Threading.Tasks;

namespace Planner.DataAccess.Interfaces.Repositories
{
    public interface IAssignmentRepository : IRepository<Assignment>, IAsyncRepository<Assignment>
    {
    }
}
