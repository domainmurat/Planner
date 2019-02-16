using Planner.DataAccess.Interfaces.Main;
using Planner.DataAccess.PlannerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planner.DataAccess.Interfaces.Repositories
{
    public interface ISubjectRepository : IRepository<Subject>, IAsyncRepository<Subject>
    {
    }
}
