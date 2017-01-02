using System;
using System.Linq;

class SumIntegers
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
                               .Split(' ')
                               .Select(int.Parse)
                               .ToArray();
        Console.WriteLine(numbers.Sum());
    }
}
