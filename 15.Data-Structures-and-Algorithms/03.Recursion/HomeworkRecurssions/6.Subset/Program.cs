using System;
using System.Text;

namespace _6.Subset
{
    class Program
    {
        static string[] sub = new string[] { "Rock", "Scissors", "Leave","Draw","Win","Lose" };
        static int k;
        static string[] arr;
        private static StringBuilder sb = new StringBuilder();
        static int couter;
        static void Main(string[] args)
        {
            sb = new StringBuilder();
            Console.WriteLine("Please Enter how many words you like to combine");
            k = int.Parse(Console.ReadLine());
            arr = new string[k];
            Generate(0,0);
            Console.WriteLine($"All posible combinations are {couter}");
        }

        private static void Generate(int index, int start)
        {
            if (index >= k)
            {
                couter++;
                Print(arr);
            }
            else
            {
                for (int i = start; i < sub.Length; i++)
                {
                    arr[index] = sub[i];
                    Generate(index +1, i+1);
                }
            }
        }

        private static void Print(string[] arr)
        {
            sb.Append("(");
            for (int i = 0; i < arr.Length; i++)
            {

                
                if(i == arr.Length - 1)
                {
                    sb.Append($"{arr[i]}");

                }

                else
                {
                    sb.Append($"{arr[i]} ");

                }
            }
            sb.Append("), ");

            Console.WriteLine(sb.ToString());
            sb.Clear();
        }
    }
}
