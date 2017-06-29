using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Permutations_No_Reps
{
    public static class Cat
    {
        public static string Brown
        {
            get
            {
                return "BrownCat";
            }
        }

        public static string Yellow
        {
            get
            {
                return "YellowCat";
            }
        }

        public static string Black
        {
            get
            {
                return "BlackCat";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new string[] { Cat.Black,Cat.Yellow,Cat.Brown };
            GeneratePermutations(arr, 0);
        }

        private static void GeneratePermutations<T>(T[] arr, int index)
        {
            if(index>= arr.Length)
            {
                Print(arr);
            }

            else
            {
                GeneratePermutations(arr, index + 1);
                for (int i = index+1; i < arr.Length; i++)
                {
                    Swap(ref arr[index], ref arr[i]);
                    GeneratePermutations(arr, index + 1);
                    Swap(ref arr[index], ref arr[i]);
                }
            }
        }

        private static void Swap<T>(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
