using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Combinations
{
    class Program
    {
        private static int[] arr;
        private static int n;
        private static int k;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = n;
            arr = new int[k];
            Generate(0);

        }

        private static void Generate(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ",arr));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i + 1;
                    Generate(index + 1);
                }
            }
        }
    }
}
