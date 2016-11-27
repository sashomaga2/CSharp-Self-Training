namespace Identity.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Identity.Models.ApplicationDbContext";
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
        {
            //var hasher = new PasswordHasher();
            //context.Users.AddOrUpdate(u => u.UserName,
            //    new ApplicationUser { UserName = "sasho", PasswordHash = hasher.HashPassword("password") }
            //);

            if(!context.Users.Any(u => u.UserName == "gosho@abv.bg"))
            {
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser { UserName = "gosho@abv.bg", Email = "gosho@abv.bg" };
                userManager.Create(user, "Tornado3!");
            }
        }
    }
}
