using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Planner.DataAccess.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.DataAccess.Context
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<PlannerContext>
    {
        protected override void Seed(PlannerContext context)
        {
            if (!context.Users.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(store);
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = "Admin";
                IdentityRole identityRole2 = new IdentityRole();
                identityRole2.Name = "Normal";
                roleManager.Create(identityRole);
                roleManager.Create(identityRole2);
            }

            if (!context.Users.Any())
            {
                var user = new User
                {
                    FirstName = "Murat Can",
                    LastName = "OGUZHAN",
                    Email = "m.c.ogzhan@gmail.com",
                    UserName = "m.c.ogzhan@gmail.com",
                    PhoneNumber = "905388758610"
                };

                var user2 = new User
                {
                    FirstName = "Medyasoft",
                    LastName = "Soft",
                    Email = "medyasoft@medyasoft.com.tr",
                    UserName = "medyasoft@medyasoft.com.tr"
                };

                var user3 = new User
                {
                    FirstName = "Test",
                    LastName = "User",
                    Email = "test@test.com",
                    UserName = "test@test.com"
                };

                var user4 = new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com"
                };

                var userStore = new UserStore<User>(context);
                var manager = new UserManager<User>(userStore);
                manager.Create(user, "Test1234_");
                manager.Create(user2, "Test1234_");
                manager.Create(user3, "Test1234_");
                manager.Create(user4, "Test1234_");

                manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user2.Id, "Admin");
                manager.AddToRole(user3.Id, "Normal");
                manager.AddToRole(user4.Id, "Admin");
            }
        }
    }
}
