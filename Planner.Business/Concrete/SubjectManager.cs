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

        public void ChangeParent(Subject subject, string userId)
        {
            var children = GetChildren(subject, new List<Subject>());

            Subject subjectEntity = GetById(subject.Id);

            subjectEntity.UserId = userId;
            subjectEntity.Name = subject.Name;
            subjectEntity.Detail = subject.Detail;
            int? currentParentId = subjectEntity.ParentSubjectId;
            subjectEntity.ParentSubjectId = subject.ParentSubjectId;
            subjectEntity.UserId = userId;

            if (children.Any(x => x.Id == subject.ParentSubjectId))
            {
                Subject parentSubjectEntity = GetById(subject.ParentSubjectId.GetValueOrDefault());
                parentSubjectEntity.ParentSubjectId = currentParentId;
                Update(parentSubjectEntity);
            }

            Update(subjectEntity);
        }

        public IList<Subject> GetChildren(Subject subject, List<Subject> childrenSubjects)
        {
            List<Subject> children = GetAllListWithoutDeleted(x => x.ParentSubjectId == subject.Id).ToList();

            childrenSubjects.AddRange(children);

            foreach (var item in children)
            {
                GetChildren(item, childrenSubjects);
            }

            return childrenSubjects;
        }
    }
}
