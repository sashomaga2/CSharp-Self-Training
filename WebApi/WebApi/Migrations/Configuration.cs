namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Models.VideoDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApi.Models.VideoDb context)
        {
            context.Videos.AddOrUpdate(v => v.Title, // how to diferenciate 1 video from another
                new Video() { Title = "MVC4", Length = 120 },
                new Video() { Title = "Linq", Length = 60 }
            );

            context.SaveChanges();

        }
    }
}
