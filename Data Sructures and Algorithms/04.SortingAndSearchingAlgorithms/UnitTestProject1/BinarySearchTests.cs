using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearchFindExistingAtEndTest()
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

            bool found = collection.BinarySearch(34);

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void BinarySearchFindExistingAtBeginningTest()
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

            bool found = collection.BinarySearch(0);

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void BinarySearchFindExistingInMiddleTest()
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
        public void BinarySearchFindNonExistingAtEndTest()
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
        public void BinarySearchFindNonExistingAtBeginningTest()
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
        public void BinarySearchFindNonExistingInMiddleTest()
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
