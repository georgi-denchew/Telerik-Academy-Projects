using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class LinearSearchTests
    {
        [TestMethod]
        public void LinearSearchFindExistingAtBeginningTest()
        {
            List<int> list = new List<int>();
            list.Add(9);
            list.Add(2);
            list.Add(15);
            list.Add(5);
            list.Add(8);
            list.Add(0);
            list.Add(1);
            list.Add(34);
            list.Add(22);
            list.Add(18);
            list.Add(19);
            list.Add(12);

            SortableCollection<int> collection = new SortableCollection<int>(list);
            collection.Sort(new MergeSorter<int>());

            bool found = collection.LinearSearch(0);

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void LinearSearchFindExistingAtEndTest()
        {
            List<int> list = new List<int>();
            list.Add(9);
            list.Add(2);
            list.Add(15);
            list.Add(5);
            list.Add(8);
            list.Add(0);
            list.Add(1);
            list.Add(34);
            list.Add(22);
            list.Add(18);
            list.Add(19);
            list.Add(12);

            SortableCollection<int> collection = new SortableCollection<int>(list);
            collection.Sort(new MergeSorter<int>());

            bool found = collection.LinearSearch(34);

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void LinearSearchFindNonExistingTest()
        {
            List<int> list = new List<int>();
            list.Add(9);
            list.Add(2);
            list.Add(15);
            list.Add(5);
            list.Add(8);
            list.Add(0);
            list.Add(1);
            list.Add(34);
            list.Add(22);
            list.Add(18);
            list.Add(19);
            list.Add(12);

            SortableCollection<int> collection = new SortableCollection<int>(list);
            collection.Sort(new MergeSorter<int>());

            bool found = collection.LinearSearch(100);

            Assert.IsFalse(found);
        }

        [TestMethod]
        public void LinearSearchFindExistingInMiddleTest()
        {
            List<int> list = new List<int>();
            list.Add(9);
            list.Add(2);
            list.Add(15);
            list.Add(5);
            list.Add(8);
            list.Add(0);
            list.Add(1);
            list.Add(34);
            list.Add(22);
            list.Add(18);
            list.Add(19);
            list.Add(12);

            SortableCollection<int> collection = new SortableCollection<int>(list);
            collection.Sort(new MergeSorter<int>());

            bool found = collection.LinearSearch(15);

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void LinearSearchFindNonExistingAtBeginningTest()
        {
            List<int> list = new List<int>();
            list.Add(9);
            list.Add(2);
            list.Add(15);
            list.Add(5);
            list.Add(8);
            list.Add(0);
            list.Add(1);
            list.Add(34);
            list.Add(22);
            list.Add(18);
            list.Add(19);
            list.Add(12);

            SortableCollection<int> collection = new SortableCollection<int>(list);
            collection.Sort(new MergeSorter<int>());

            bool found = collection.LinearSearch(-15);

            Assert.IsFalse(found);
        }

        [TestMethod]
        public void LinearSearchFindNonExistingInMiddleTest()
        {
            List<int> list = new List<int>();
            list.Add(9);
            list.Add(2);
            list.Add(15);
            list.Add(5);
            list.Add(8);
            list.Add(0);
            list.Add(1);
            list.Add(34);
            list.Add(22);
            list.Add(18);
            list.Add(19);
            list.Add(12);

            SortableCollection<int> collection = new SortableCollection<int>(list);
            collection.Sort(new MergeSorter<int>());

            bool found = collection.LinearSearch(14);

            Assert.IsFalse(found);
        }
    }
}
