using Planner.Business.Abstract;
using Planner.Business.Dtos;
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

        public SubjectManager(PlannerContext plannerContext) : base(plannerContext)
        {

        }

        public void ChangeParent(Subject subject, string userId)
        {
            var children = GetAllChildren(subject, new List<Subject>());

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

        public IList<Subject> GetAllChildren(Subject subject, List<Subject> childrenSubjects)
        {
            List<Subject> children = GetChildren(subject);

            childrenSubjects.AddRange(children);

            foreach (var item in children)
            {
                GetAllChildren(item, childrenSubjects);
            }

            return childrenSubjects;
        }

        public List<Subject> GetChildren(Subject subject)
        {
            return GetAllListWithoutDeleted(x => x.ParentSubjectId == subject.Id).ToList();
        }

        public List<Child> GetSubjectSchema(string userId)
        {
            var currentUserParentSubjects = _dbSet.Where(x => x.UserId == userId
            && (x.ParentSubjectId == null || x.ParentSubjectId == 0) && !x.Deleted).ToList();

            List<Child> children = new List<Child>();

            foreach (var item in currentUserParentSubjects)
            {
                var main = new Child() { text = new Text() { name = item.Name } };
                CreateHierarchy(item, main);
                children.Add(main);
            }

            return children;
        }

        private void CreateHierarchy(Subject item, Child main)
        {
            if (item.ChildrenSubjectsOfParent != null)
            {
                var childrenSubjectsOfParent = item.ChildrenSubjectsOfParent.Where(x => !x.Deleted);
                foreach (var subject in childrenSubjectsOfParent)
                {
                    Child child = new Child();
                    child.text = new Text() { name = subject.Name };
                    main.children.Add(child);
                    if (subject.ChildrenSubjectsOfParent != null)
                    {
                        CreateHierarchy(subject, child);
                    }
                }
            }
        }
    }
}
