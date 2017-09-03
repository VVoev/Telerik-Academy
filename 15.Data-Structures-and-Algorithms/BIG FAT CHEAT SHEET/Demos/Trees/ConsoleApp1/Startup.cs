using System;

namespace ConsoleApp1
{
    using HeapSort;

    public class Startup
    {
        public static void Main()
        {
            var arr = new int[20];
            var random = new Random();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr.Length - i;
            }

            Console.WriteLine(string.Join(" ", arr));
            arr.HeapSort((a, b) => a > b);
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}