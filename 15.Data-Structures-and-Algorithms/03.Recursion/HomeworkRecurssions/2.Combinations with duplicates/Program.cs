using System;
using System.Text;

namespace _2.Combinations_with_duplicates
{
    class Program
    {
        static int n = 49;
        static int k = 6;
        static int[] arr;


        static void Main(string[] args)
        {
            arr = new int[k];
            FillArr(0,1);
        }

        private static void FillArr(int index, int start)
        {
            if(index >= k)
            {
                Print(arr);
                return;
            }

            else
            {
                for (int i = start; i <= n  ; i++)
                {
                    arr[index] = i;
                    FillArr(index + 1, i);
                }
            }
        }

        private static void Print(int[] arr)
        {
            var sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < arr.Length; i++)
            {
                if(i == arr.Length - 1)
                {
                    sb.Append(string.Format($"{arr[i]}"));
                }

                else
                {
                    sb.Append(string.Format($"{arr[i]} "));
                }

            }
            sb.Append(")");
            Console.WriteLine(sb);
        }
    }
}
