using NUnit.Framework;
using SortingHomework;
using System.Collections.Generic;

namespace SearchingHomework.Tests.SortableCollectionTests
{
    [TestFixture]
    public class BinarySearch_Should
    {
        [Test]
        public void ReturnNegativeNumber_WhenSearchedItemIsNotPresentInCollection()
        {
            // arrange
            var sortableCollection = new SortableCollection<int>();
            var numbers = new List<int>() { 0, 1, 2, 3, 18, 44, 90 };
            foreach (var number in numbers)
            {
                sortableCollection.Items.Add(number);
            }

            // act
            int index = sortableCollection.BinarySearch(81);

            // assert
            Assert.IsTrue(index < 0);
        }

        [Test]
        public void ReturnCorrectIndex_WhenSearchedItemIsPresentInCollection()
        {
            // arrange
            var sortableCollection = new SortableCollection<int>();
            var numbers = new List<int>() { 0, 1, 2, 3, 18, 44, 90 };
            foreach (var number in numbers)
            {
                sortableCollection.Items.Add(number);
            }

            // act
            int index = sortableCollection.BinarySearch(18);

            // assert
            Assert.AreEqual(4, index);
        }
    }
}