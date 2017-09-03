using NUnit.Framework;

namespace SortinAlgorithms.Tests.QuickSorterTests
{
    [TestFixture]
    public class Start_Should
    {
        [Test]
        public void SortIntsArrayCorrectly_WhenCalled()
        {
            // arrange
            var elements = new int[] { 0, 14, 1, 3, 128, -5, 17 };
            var expectedElements = new int[] { -5, 0, 1, 3, 14, 17, 128 };

            var quickSorter = new SortingAlgorithms.QuickSorter<int>();

            // act
            quickSorter.Sort(elements);

            // assert
            CollectionAssert.AreEqual(elements, expectedElements);
        }

        [Test]
        public void SortStringsArrayCorrectly_WhenCalled()
        {
            // arrange
            var elements = new string[] { "zebra", "apple", "kiwi", "some", "word", };
            var expectedElements = new string[] { "apple", "kiwi", "some", "word", "zebra" };

            var quickSorter = new SortingAlgorithms.QuickSorter<string>();

            // act
            quickSorter.Sort(elements);

            // assert
            CollectionAssert.AreEqual(elements, expectedElements);
        }
    }
}
