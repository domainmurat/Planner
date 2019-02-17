namespace Planner.DataAccess.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Planner.DataAccess.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Planner.DataAccess.Context.PlannerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(Planner.DataAccess.Context.PlannerContext context)
        //{
        //    if (!context.Users.Any())
        //    {
        //        var store = new RoleStore<IdentityRole>(context);
        //        var roleManager = new RoleManager<IdentityRole>(store);
        //        IdentityRole identityRole = new IdentityRole();
        //        identityRole.Name = "Admin";
        //        IdentityRole identityRole2 = new IdentityRole();
        //        identityRole2.Name = "Normal";
        //        roleManager.Create(identityRole);
        //        roleManager.Create(identityRole2);
        //    }

        //    if (!context.Users.Any())
        //    {
        //        var user = new User
        //        {
        //            FirstName = "Murat Can",
        //            LastName = "OGUZHAN",
        //            Email = "m.c.ogzhan@gmail.com",
        //            UserName = "m.c.ogzhan@gmail.com",
        //            PhoneNumber = "905388758610"
        //        };

        //        var user2 = new User
        //        {
        //            FirstName = "Medyasoft",
        //            LastName = "Soft",
        //            Email = "medyasoft@medyasoft.com.tr",
        //            UserName = "medyasoft@medyasoft.com.tr"
        //        };

        //        var user3 = new User
        //        {
        //            FirstName = "Test",
        //            LastName = "User",
        //            Email = "test@test.com",
        //            UserName = "test@test.com"
        //        };

        //        var userStore = new UserStore<User>(context);
        //        var manager = new UserManager<User>(userStore);
        //        manager.Create(user, "Test1234_");
        //        manager.Create(user2, "Test1234_");
        //        manager.Create(user3, "Test1234_");

        //        manager.AddToRole(user.Id, "Admin");
        //        manager.AddToRole(user2.Id, "Admin");
        //        manager.AddToRole(user3.Id, "Normal");
        //    }

        //}
    }
}
