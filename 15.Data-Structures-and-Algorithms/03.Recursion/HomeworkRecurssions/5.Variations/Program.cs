using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Variations
{
    class Program
    {
        static int k = 5;
        static string[] arr;
        private static string[] set;
        static void Main(string[] args)
        {
            arr = new string[k];
            set = new string[] { "Hi", "A", "B","Vlado","Test" };
            Generate(0);
        }

        private static void Generate(int index)
        {
            if(index >= k)
            {
                Print(arr);
            }

            else
            {
                for (int i = 0; i <k ; i++)
                {
                    arr[index] = set[i];
                    Generate(index + 1);
                }
            }
        }

        public static void Print(string[] arr)
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
