using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Entities.Concrete
{
    public class Subject : BaseEntity
    {
        public Subject()
        {
            Assignments = new HashSet<Assignment>();
            ChildrenSubjectsOfParent = new HashSet<Subject>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        public int ParentSubjectId { get; set; }
        public int UserId { get; set; }

        public virtual Subject ParentSubject { get; set; }
        public virtual ICollection<Subject> ChildrenSubjectsOfParent { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }

    public class Assignment : BaseEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
