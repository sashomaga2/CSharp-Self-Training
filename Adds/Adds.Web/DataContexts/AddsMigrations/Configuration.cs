namespace Adds.Web.DataContexts.AddsMigrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Adds.Web.DataContexts.AddsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DataContexts\AddsMigrations";
        }

        protected override void Seed(Adds.Web.DataContexts.AddsDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Adds.AddOrUpdate(a => a.Title,
                new Add { Title = "First Add", Context = "Some text" },
                new Add { Title = "Second Add", Context = "Some other text" }
            );
        }
    }
}
