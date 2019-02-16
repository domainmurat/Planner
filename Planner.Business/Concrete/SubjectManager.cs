using Planner.Business.Abstract;
using Planner.DataAccess.Concrete;
using Planner.DataAccess.Context;
using Planner.DataAccess.Interfaces.Repositories;
using Planner.DataAccess.PlannerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Business.Concrete
{
    public class SubjectManager : SubjectRepository, ISubjcetService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectManager(PlannerContext plannerContext, ISubjectRepository subjectRepository) : base(plannerContext)
        {
            _subjectRepository = subjectRepository;
        }
    }
}
