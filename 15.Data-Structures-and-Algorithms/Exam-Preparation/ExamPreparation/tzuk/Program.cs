using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Program
    {
        private static int n;
        private static long counter;
        private static int k;
        private static int[] arr;
        static void Main(string[] args)
        {
            Console.WriteLine($"Please enter two numbers in order to see the chanse of guessing the combination or press X to quit");
            string choise = string.Empty;
            while (!choise.StartsWith("X")|| choise.StartsWith("x"))
            {
                n = int.Parse(Console.ReadLine());
                k = int.Parse(Console.ReadLine());
                arr = new int[n];


                Recurssion(0, 1);
                Console.WriteLine(counter);
                choise = UserChoise();
            }
            if (choise.StartsWith("X") || choise.StartsWith("x"))
            {
                Environment.Exit(-1);
            }
        }

        private static string UserChoise()
        {
            Console.WriteLine($"Please enter two numbers in order to see the chanse of guessing the combination or press X to quit or type OK to continue");
            var choise = Console.ReadLine();
            return choise;
        }

        private static void Recurssion(int index, int current)
        {
            if (index >= n)
            {
                //Print(arr);
                counter++;
                return;
            }
            for (int j = current; j <= k; j++)
            {
                arr[index] = j;
                Recurssion(index + 1, j + 1);
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
