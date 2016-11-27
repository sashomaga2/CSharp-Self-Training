namespace eManager.Web.Migrations
{
    using Domain;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
        {
            //  This method will be called after migrating to the latest version.

            //AddUserAndRole(context)
            context.Departments.AddOrUpdate(d => d.Name,
                new Department() { Name = "Engineering" },
                new Department() { Name = "Sales" },
                new Department() { Name = "Shipping" },
                new Department() { Name = "Human Resources" }
                );

        }

        bool AddUserAndRole(eManager.Web.Infrastructure.DepartmentDb context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("Admin"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "Admin");
            return ir.Succeeded;
        }

        //protected override void Seed(IdentityDbContext context)
        //{
        //    if (!context.Roles.Any(r => r.Name == "AppAdmin"))
        //    {
        //        var store = new RoleStore<IdentityRole>(context);
        //        var manager = new RoleManager<IdentityRole>(store);
        //        var role = new IdentityRole { Name = "AppAdmin" };

        //        manager.Create(role);
        //    }

        //    if (!context.Users.Any(u => u.UserName == "founder"))
        //    {
        //        var store = new UserStore<ApplicationUser>(context);
        //        var manager = new UserManager<ApplicationUser>(store);
        //        var user = new ApplicationUser { UserName = "founder" };

        //        manager.Create(user, "ChangeItAsap!");
        //        manager.AddToRole(user.Id, "AppAdmin");
        //    }
        //}
    }
}
