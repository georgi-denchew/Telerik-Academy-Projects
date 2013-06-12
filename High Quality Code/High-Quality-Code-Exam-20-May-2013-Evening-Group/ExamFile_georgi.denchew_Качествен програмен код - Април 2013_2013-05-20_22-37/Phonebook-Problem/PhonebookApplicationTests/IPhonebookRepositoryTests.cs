namespace PhonebookApplicationTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PhonebookApplication;

    [TestClass]
    public class IPhonebookRepositoryTests
    {
        [TestMethod]
        public void TestAddPhoneMethodSingleEntry()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });

            Assert.AreEqual(1, repository.EntriesCount);
        }

        [TestMethod]
        public void TestAddPhoneMethodSingleEntryAllVariations()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho"
                , new string[] { " 02 / 0123456789", "+35912345", "(+359) 897555222" });

            Assert.AreEqual(1, repository.EntriesCount);
        }

        [TestMethod]
        public void TestAddPhoneMethodSingleEntryLostOfNumbers()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789", "12454323", "1234543234", "123467643" });

            Assert.AreEqual(1, repository.EntriesCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddPhoneMethodInvalidNameEntry()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone(string.Empty, new string[] { "0123456789" });

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddPhoneMethodNullNameEntry()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone(null, new string[] { "0123456789" });
        }

        [TestMethod]
        public void TestAddPhoneMethodNewEntry()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool actual = repository.AddPhone("Pesho", new string[] { "0123456789" });

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestAddPhoneMethodExistingEntry()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            bool actual = repository.AddPhone("Pesho", new string[] { "1234211233" });

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TestAddPhoneMethodTwoSameNameEntries()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Pesho", new string[] { "0234567899" });

            Assert.AreEqual(1, repository.EntriesCount);
        }

        [TestMethod]
        public void TestAddPhoneMethodTwoDifferentEntries()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0234567899" });

            Assert.AreEqual(2, repository.EntriesCount);
        }

        [TestMethod]
        public void TestAddPhoneMethodLotsOfDifferentEntries()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0234567899" });
            repository.AddPhone("Tosho", new string[] { "9234567899" });
            repository.AddPhone("Prosho", new string[] { "7234567899" });
            repository.AddPhone("Smosho", new string[] { "1234567899" });
            repository.AddPhone("gesho", new string[] { "0123456789" });
            repository.AddPhone("vosho", new string[] { "0234567899" });
            repository.AddPhone("kosho", new string[] { "9234567899" });
            repository.AddPhone("rosho", new string[] { "7234567899" });
            repository.AddPhone("klosho", new string[] { "1234567899" });
            Assert.AreEqual(10, repository.EntriesCount);
        }

        [TestMethod]
        public void TestAddPhoneMethodTwoEntries()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0234567899" });

            Assert.AreEqual(2, repository.EntriesCount);
        }

        [TestMethod]
        public void TestChangeNumberMethodOneNumber()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0234567899" });
            int changesMade = repository.ChangePhone("0123456789", "123456789");
            Assert.AreEqual(1, changesMade);
        }

        [TestMethod]
        public void TestChangeNumberMethodTwoNumbers()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0123456789" });
            int changesMade = repository.ChangePhone("0123456789", "123456789");
            Assert.AreEqual(2, changesMade);
        }

        [TestMethod]
        public void TestChangeNumberMethodNonexistingNumber()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0123456789" });
            int changesMade = repository.ChangePhone("0000", "123456789");
            Assert.AreEqual(0, changesMade);
        }

        [TestMethod]
        public void TestChangeNumberMethodSameNumbersOneEntry()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789", "234", "237" });
            int changesMade = repository.ChangePhone("0123456789", "123456789");
            Assert.AreEqual(1, changesMade);
        }

        [TestMethod]
        public void TestChangeNumberMethodSameNumberTwoEntries()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789", "234", "237" });
            repository.AddPhone("gosho", new string[] { "777", "0123456789", "8888" });
            int changesMade = repository.ChangePhone("0123456789", "123456789");
            Assert.AreEqual(2, changesMade);
        }

        [TestMethod]
        public void TestChangeNumberMethodTenEntries()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0123456789" });
            repository.AddPhone("Tosho", new string[] { "0123456789" });
            repository.AddPhone("Prosho", new string[] { "0123456789" });
            repository.AddPhone("Smosho", new string[] { "0123456789" });
            repository.AddPhone("gesho", new string[] { "0123456789" });
            repository.AddPhone("vosho", new string[] { "0123456789" });
            repository.AddPhone("kosho", new string[] { "0123456789" });
            repository.AddPhone("rosho", new string[] { "0123456789" });
            repository.AddPhone("klosho", new string[] { "0123456789" });
            int changesMade = repository.ChangePhone("0123456789", "1234");

            Assert.AreEqual(10, changesMade);
        }

        [TestMethod]
        public void TestChangeNumberMethodTenEntriesNonMatch()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0123456789" });
            repository.AddPhone("Tosho", new string[] { "0123456789" });
            repository.AddPhone("Prosho", new string[] { "0123456789" });
            repository.AddPhone("Smosho", new string[] { "0123456789" });
            repository.AddPhone("gesho", new string[] { "0123456789" });
            repository.AddPhone("vosho", new string[] { "0123456789" });
            repository.AddPhone("kosho", new string[] { "0123456789" });
            repository.AddPhone("rosho", new string[] { "0123456789" });
            repository.AddPhone("klosho", new string[] { "0123456789" });
            int changesMade = repository.ChangePhone("5444423", "1234");

            Assert.AreEqual(0, changesMade);
        }

        [TestMethod]
        public void TestChangeNumberMethodTenEntriesTwoMatch()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0123456789" });
            repository.AddPhone("Tosho", new string[] { "0123456789" });
            repository.AddPhone("Prosho", new string[] { "0123456789" });
            repository.AddPhone("Smosho", new string[] { "0123456789" });
            repository.AddPhone("gesho", new string[] { "0123456789" });
            repository.AddPhone("vosho", new string[] { "5444423" });
            repository.AddPhone("kosho", new string[] { "0123456789" });
            repository.AddPhone("rosho", new string[] { "0123456789" });
            repository.AddPhone("klosho", new string[] { "5444423" });
            int changesMade = repository.ChangePhone("5444423", "1234");

            Assert.AreEqual(2, changesMade);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListEntriesMethodInvalidIndex()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.ListEntries(2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListEntriesMethodInvalidCount()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            Assert.AreEqual(repository.ListEntries(0, 2).Length, 2);
        }

        [TestMethod]
        public void TestListEntriesMethodCountTen()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0123456789" });
            repository.AddPhone("Tosho", new string[] { "0123456789" });
            repository.AddPhone("Prosho", new string[] { "0123456789" });
            repository.AddPhone("Smosho", new string[] { "0123456789" });
            repository.AddPhone("gesho", new string[] { "0123456789" });
            repository.AddPhone("vosho", new string[] { "5444423" });
            repository.AddPhone("kosho", new string[] { "0123456789" });
            repository.AddPhone("rosho", new string[] { "0123456789" });
            repository.AddPhone("klosho", new string[] { "5444423" });

            Assert.AreEqual(repository.ListEntries(0, 10).Length, 10);
        }

        [TestMethod]
        public void TestListEntriesMethodStartIndexTen()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0123456789" });
            repository.AddPhone("Tosho", new string[] { "0123456789" });
            repository.AddPhone("Prosho", new string[] { "0123456789" });
            repository.AddPhone("Smosho", new string[] { "0123456789" });
            repository.AddPhone("gesho", new string[] { "0123456789" });
            repository.AddPhone("vosho", new string[] { "5444423" });
            repository.AddPhone("kosho", new string[] { "0123456789" });
            repository.AddPhone("rosho", new string[] { "0123456789" });
            repository.AddPhone("klosho", new string[] { "5444423" });

            Assert.AreEqual(repository.ListEntries(1, 9).Length, 9);
        }

        [TestMethod]
        public void TestListEntriesMethodOneEntryManyNumbers()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] 
            { 
                "0123456789", "01234567899", "01234567189", "0123456789",
                "01234561789", "230123456789"
            });
            Assert.AreEqual(repository.ListEntries(0, 1).Length, 1);
        }

        [TestMethod]
        public void TestListEntriesStratIndexFiveCountFive()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new string[] { "0123456789" });
            repository.AddPhone("Gosho", new string[] { "0123456789" });
            repository.AddPhone("Tosho", new string[] { "0123456789" });
            repository.AddPhone("Prosho", new string[] { "0123456789" });
            repository.AddPhone("Smosho", new string[] { "0123456789" });
            repository.AddPhone("gesho", new string[] { "0123456789" });
            repository.AddPhone("vosho", new string[] { "5444423" });
            repository.AddPhone("kosho", new string[] { "0123456789" });
            repository.AddPhone("rosho", new string[] { "0123456789" });
            repository.AddPhone("klosho", new string[] { "5444423", "1234543" });

            Assert.AreEqual(repository.ListEntries(5, 5).Length, 5);
        }        
    }
}
