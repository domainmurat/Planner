using Planner.Business.Dtos;
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
        IList<Subject> GetAllChildren(Subject subject, List<Subject> childrenSubjects);
        List<Subject> GetChildren(Subject subject);
        List<Child> GetSubjectSchema(string userId);
    }
}
