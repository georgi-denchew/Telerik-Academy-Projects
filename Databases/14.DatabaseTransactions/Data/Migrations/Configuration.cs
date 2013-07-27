namespace Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Data.ATM>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.ATM context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            List<CardAccount> cardAccounts = new List<CardAccount>() 
            {
              new CardAccount { CardNumber = "1234567890", CardPin = "1234", CardCash = 3000 },
              new CardAccount { CardNumber = "1234561234", CardPin = "2345", CardCash = 5000 },
              new CardAccount { CardNumber = "0987654321", CardPin = "9765", CardCash = 10000 }
            };

            foreach (var card in cardAccounts)
            {
                if (context.CardAccounts.FirstOrDefault(ca => ca.CardNumber == card.CardNumber) == null)
                {
                    context.CardAccounts.Add(card);
                }
            }

            try
            {
                string query = "ALTER TABLE CardAccounts ADD" +
                    " CONSTRAINT AK_CardNumber UNIQUE(CardNumber)";
                context.Database.ExecuteSqlCommand(query);
            }
            catch (Exception e)
            {

            }

            context.SaveChanges();
        }
    }
}
