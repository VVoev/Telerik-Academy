using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.N_Nested_Loops
{
    class Program
    {
        private static int[] arr;
        private static int k;
        private static int n;

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            n = number;
            arr = new int[number];
            k = number;
            NestedLoops(0);
        }

        private static void NestedLoops(int index)
        {
            if (index >=k)
            {
                Print(arr);
            }

            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i + 1;
                    NestedLoops(index +1);
                }
            }
        }

        private static void Print(int[] arr)
        {
            foreach (var a in arr)
            {
                Console.Write(a);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}
