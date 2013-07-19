namespace UnitTestProject2
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;
    using System.Collections.Generic;

    [TestClass]
    public class SelectionSorterTests
    {
        [TestMethod]
        public void SelctionSortTest()
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
            collection.Sort(new SelectionSorter<int>());

            bool allInOrder = true;

            for (int index = 0; index < collection.Items.Count - 1; index++)
            {
                if (collection.Items[index] > collection.Items[index + 1])
                {
                    allInOrder = false;
                }
            }

            Assert.AreEqual(list.Count, collection.Items.Count);
            Assert.IsTrue(allInOrder);
        }
    }
}
