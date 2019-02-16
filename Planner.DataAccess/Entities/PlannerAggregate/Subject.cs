using Planner.DataAccess.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.DataAccess.PlannerAggregate
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

        public int? ParentSubjectId { get; set; }
        public string UserId { get; set; }

        public virtual Subject ParentSubject { get; set; }
        public virtual ICollection<Subject> ChildrenSubjectsOfParent { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual User User { get; set; }
    }
}
