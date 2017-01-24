using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NestedLoops
{
    class NestedLoops
    {
        private static int[] arr;
        private static int k;
        private static int n;
        private static int counter;


        static void Main(string[] args)
        {

            Console.WriteLine($"Enter a number N");
            n = int.Parse(Console.ReadLine());
            k = n;
            arr = new int[k];
            Generate(0);
            Console.WriteLine(counter);

        }

        private static void Generate(int index)
        {
            //Recurssion bottom
            if (index >= k)
            {
                //Console.WriteLine(string.Join(" ",arr));
                counter++;
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
