namespace KendoMVCDemo.Migrations
{
    using KendoMVCDemo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KendoMVCDemo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KendoMVCDemo.Models.ApplicationDbContext context)
        {
            //this.PopulateDatabase(context);
        }

        private void PopulateDatabase(Models.ApplicationDbContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var category = new Category();
                category.Name = "Category " + i;

                for (int j = 0; j < 10; j++)
                {
                    var book = new Book()
                    {
                        Title = "Title " + i + " " + j,
                        Content = "Content " + i + " " + j,
                        Author = "Author " + i + " " + j
                    };

                    category.Books.Add(book);
                }

                context.Categories.Add(category);
            }
        }
    }
}
