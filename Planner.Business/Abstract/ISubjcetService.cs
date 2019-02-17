using Planner.DataAccess.Interfaces.Repositories;
using Planner.DataAccess.PlannerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Business.Abstract
{
    public interface ISubjcetService : ISubjectRepository
    {
        void ChangeParent(Subject subject, string userId);
        IList<Subject> GetChildren(Subject subject, List<Subject> childrenSubjects);
    }
}
