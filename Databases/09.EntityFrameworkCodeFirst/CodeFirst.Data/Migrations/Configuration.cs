namespace CodeFirst.Data.Migrations
{
    using CodeFirst.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CodeFirst.Data.AcademyContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirst.Data.AcademyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Homeworks.AddOrUpdate(
              new Homework { Content = "First Homework", Deadline = DateTime.Now },
              new Homework { Content = "Second Homework", Deadline = DateTime.Now },
              new Homework { Content = "Third Homework", Deadline = DateTime.Now }
            );
            
        }
    }
}
