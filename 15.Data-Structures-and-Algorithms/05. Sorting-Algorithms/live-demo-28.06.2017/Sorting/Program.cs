using System;

namespace Sorting
{
    public class Program
    {
        static void Main()
        {
            BasicInput();

        }

        private static void BasicInput()
        {
            const int size = 100000;
            var arr = new int[size];

            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next() % 10000000;
            }
        }
    }
}
