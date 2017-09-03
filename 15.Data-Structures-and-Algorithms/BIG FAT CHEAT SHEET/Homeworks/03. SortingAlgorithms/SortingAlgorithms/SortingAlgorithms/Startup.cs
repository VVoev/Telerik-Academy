using SortingAlgorithms;

namespace ConsoleApp1
{
    public class Startup
    {
        public static void Main()
        {
            var elements = new int[] { 3, 4, 18, 22, 11, 44, 33, 0, -1 };
            var selectionSorter = new SelectionSorter<int>();
            var quickSorter = new QuickSorter<int>();
            var mergeSorter = new MergeSorter<int>();
            //selectionSorter.Sort(elements);
            quickSorter.Sort(elements);
            //mergeSorter.Sort(elements);

            System.Console.WriteLine(string.Join(", ", elements));
        }
    }
}
