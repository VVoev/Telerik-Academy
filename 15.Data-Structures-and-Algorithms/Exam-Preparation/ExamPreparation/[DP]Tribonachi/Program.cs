using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _DP_Tribonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var first = input[0];
            var second = input[1];
            var third = input[2];
            var numbers = new List<BigInteger>();
            numbers.Add(first);
            numbers.Add(second);
            numbers.Add(third);
            

            var searchedNumber = input[3];

            if (searchedNumber <= 3)
            {
                Console.WriteLine(numbers[(int)searchedNumber-1]);
                Environment.Exit(1);
            }
            BigInteger number = 0;
            for (int i = numbers.Count-1; i < searchedNumber-1; i++)
            {
                 number = numbers[i - 2] + numbers[i - 1] + numbers[i];
                numbers.Add(number);
            }

            Console.WriteLine(number);


        }
    }
}
