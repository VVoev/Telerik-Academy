using System;

namespace _Combinatorics_DoublePassword
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            long sum = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    sum *= 2;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
