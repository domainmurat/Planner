using System;

namespace Planner.DataAccess.PlannerAggregate
{
    public class Assignment : BaseEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
