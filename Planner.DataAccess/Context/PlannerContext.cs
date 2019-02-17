using Microsoft.AspNet.Identity.EntityFramework;
using Planner.DataAccess.Identity;
using Planner.DataAccess.PlannerAggregate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.DataAccess.Context
{
    public class PlannerContext : IdentityDbContext<User>
    {
        public PlannerContext()
           : base("name=cn", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Subject> Subject { get; set; }
        public DbSet<Assignment> Assignment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subject>()
             .HasMany(e => e.ChildrenSubjectsOfParent)
             .WithOptional(e => e.ParentSubject)
             .HasForeignKey(e => e.ParentSubjectId);

            modelBuilder.Entity<Subject>()
              .HasMany(e => e.Assignments)
              .WithOptional(e => e.Subject)
              .HasForeignKey(e => e.SubjectId);

            modelBuilder.Entity<User>()
             .HasMany(e => e.Subjects)
             .WithRequired(e => e.User)
             .HasForeignKey(e => e.UserId);


            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<IdentityRole>().ToTable("Role");

            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");

            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");

        }

        public static PlannerContext Create()
        {
            return new PlannerContext();
        }
    }
}
