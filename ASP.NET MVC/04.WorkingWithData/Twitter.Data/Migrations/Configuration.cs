namespace Twitter.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Twitter.Models;

    public sealed class Configuration : DbMigrationsConfiguration<Twitter.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Twitter.Data.DataContext context)
        {
            //this.Populate(context);
        }

        private void Populate(DataContext context)
        {
            var user = context.Users.FirstOrDefault(us => us.UserName == "pesho");

            for (int i = 0; i < 5; i++)
            {
                var tag = new Tag() { Title = "Pesho Tag " + i };


                for (int j = 0; j < 10; j++)
                {
                    var tweet = new Tweet();
                    tweet.Content = "Pesho Tweet content " + i + " " + j;
                    tweet.Tags.Add(tag);
                    user.Tweets.Add(tweet);
                }
            }
        }
    }
}