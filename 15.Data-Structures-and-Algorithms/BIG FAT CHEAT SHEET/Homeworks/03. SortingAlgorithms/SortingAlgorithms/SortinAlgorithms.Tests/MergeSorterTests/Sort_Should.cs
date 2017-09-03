using NUnit.Framework;
using SortingAlgorithms;

namespace SortinAlgorithms.Tests.MergeSorterTests
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

            var mergeSorter = new SortingAlgorithms.MergeSorter<int>();

            // act
            mergeSorter.Sort(elements);

            CollectionAssert.AreEqual(elements, expectedElements);
        }

        [Test]
        public void SortStringsArrayCorrectly_WhenCalled()
        {
            // arrange
            var elements = new string[] { "zebra", "apple", "kiwi", "some", "word", };
            var expectedElements = new string[] { "apple", "kiwi", "some", "word", "zebra" };

            var mergeSorter = new SortingAlgorithms.MergeSorter<string>();

            // act
            mergeSorter.Sort(elements);

            CollectionAssert.AreEqual(elements, expectedElements);
        }
    }
}
