using System;
using System.Linq;
using System.Diagnostics;
using Assertions_Homework.SortingAlgorithms;
using Assertions_Homework.SearchingAlgorithms;

class AssertionsHomework
{
    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SortingAlgo.SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SortingAlgo.SelectionSort(new int[0]); // Test sorting empty array
        SortingAlgo.SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(SearchingAlgo.BinarySearch(arr, -1000));
        Console.WriteLine(SearchingAlgo.BinarySearch(arr, 0));
        Console.WriteLine(SearchingAlgo.BinarySearch(arr, 17));
        Console.WriteLine(SearchingAlgo.BinarySearch(arr, 10));
        Console.WriteLine(SearchingAlgo.BinarySearch(arr, 1000));
    }
}
