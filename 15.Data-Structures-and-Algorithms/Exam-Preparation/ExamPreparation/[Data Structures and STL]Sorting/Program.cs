using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main()
    {
        string firstLine = Console.ReadLine();
        string[] nums = firstLine.Split(' ');
        int n = int.Parse(nums[0]);
        uint x = uint.Parse(nums[1]);

        List<uint> numbers = Input(n);
        numbers = SortUsingLINQ(numbers, x);
        Output(numbers);
    }

    static List<uint> Input(int n)
    {
        List<uint> numbers = new List<uint>();
        string secondLine = Console.ReadLine();
        string[] numbersAsString = secondLine.Split(' ');
        for (int i = 0; i < n; i++)
        {
            numbers.Add(uint.Parse(numbersAsString[i]));
        }

        return numbers;
    }

    static void Output(List<uint> numbers)
    {
        StringBuilder sb = new StringBuilder();
        foreach (uint number in numbers)
        {
            sb.AppendFormat("{0} ", number);
        }
        Console.WriteLine(sb.ToString().Trim());
    }

    static List<uint> SortUsingLINQ(List<uint> input, uint x)
    {
        List<uint> output =
            (from num in input
             orderby num
             orderby num % x
             select num).ToList();

        return output;
    }
}
