using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Combinatorics_GreatestDiviser
{

    class Program
    {
        static HashSet<int> AllCombinations = new HashSet<int>();
        static int[] array;
        static bool[] used;
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int[] arr = new int[numbers];
            used = new bool[numbers];
            array = new int[numbers];


            for (int i = 0; i < numbers; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                arr[i] = array[i];
            }

            Generate(0,arr);
            var greatestDiviser = int.MaxValue;
            var number = int.MaxValue;
            var allNumbers = new List<int>();
            foreach (var combo in AllCombinations)
            {
                var currentDiviser = 0;
                for (int i = 1; i <= combo; i++)
                {
                    if (combo % i ==0)
                    {
                        currentDiviser++;
                    }
                }
                if (currentDiviser <= greatestDiviser)
                {
                    if (currentDiviser == greatestDiviser)
                    {
                        if (combo < number)
                        {
                            number = combo;
                        }
                    }
                    else
                    {
                        greatestDiviser = currentDiviser;
                        currentDiviser = 0;
                        number = combo;
                    }
                }
            }

            Console.WriteLine(number);
            
                         
        }

        private static void Generate(int index,int[]arr)
        {
            if(index>= array.Length)
            {
                var number = string.Join("", array);
                AllCombinations.Add(int.Parse(number));
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    array[index] = arr[i];
                    Generate(index + 1, arr);
                    used[i] = false;
                }

            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(" ",array));
        }
    }
}
