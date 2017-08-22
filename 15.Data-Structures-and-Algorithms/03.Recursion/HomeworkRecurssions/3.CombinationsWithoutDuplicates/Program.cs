using System;
using System.Text;

namespace _3.CombinationsWithoutDuplicates
{
    class Program
    {
        static int n = 5;
        static int k = 35;
        static int[] arr;

        static void Main(string[] args)
        {
            arr = new int[k];
            GenerateCombinations(0, 0);
            //var x = new Random();
            //Console.WriteLine(x.Next(1, 14000000));
        }

        private static void GenerateCombinations(int index, int start)
        {
            if(index >= arr.Length)
            {
                Print(arr);
            }

            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i + 1;
                    GenerateCombinations(index+1, i+1);
                }
            }
        }

        public static void Print(int[] arr)
        {
            var sb = new StringBuilder();
            sb.Append('(');
            foreach (var v in arr)
            {
                sb.Append($"{v},");
            }
            var g = sb.ToString();
            var c = g.TrimEnd(',');
            c += ')';
            Console.WriteLine(c);
        }
    }
}
