using Data;
using Data.Migrations;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Objects;

namespace ATMApplication
{
    class ATMApplication
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATM, Configuration>());

            var db = new ATM();

            db.SaveChanges();
            decimal amount = 200;
            string cardNumber = "1234567890";
            string pin = "1234";
            RetrieveMoney(db, cardNumber, amount, pin);
        }

        private static void RetrieveMoney(ATM db, string cardNumber, decimal amount, string pin)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.Serializable }))
            {
                using (db)
                {
                    if (cardNumber.Length != 10 || pin.Length != 4)
                    {
                        throw new ArgumentException("Invalid card number or PIN.");
                    }

                    var account = db.CardAccounts.FirstOrDefault(x => x.CardNumber == cardNumber);

                    if (account == null)
                    {
                        throw new ArgumentNullException("No card with the given card number exists.");
                    }

                    if (account.CardCash < amount)
                    {
                        throw new InvalidOperationException("Not enough money in the given account.");
                    }

                    account.CardCash -= amount;
                    db.SaveChanges();
                    InsertLog(db, cardNumber, amount, DateTime.Now);
                }

                scope.Complete();
            }
        }

        private static void InsertLog(ATM db, string cardNumber, decimal amount, DateTime date)
        {
            using (db)
            {
                TransactionHistory newEntry = new TransactionHistory
                {
                    Amount = amount,
                    CardNumber = cardNumber,
                    TransactionDate = date
                };

                db.TransactionsHistory.Add(newEntry);
                db.SaveChanges();
            }
        }
    }
}