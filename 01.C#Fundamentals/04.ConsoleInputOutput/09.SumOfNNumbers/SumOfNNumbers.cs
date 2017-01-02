using System;

class SumOfNNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double result = 0;
        for (int i = 0; i < n; i++)
        {
            double numberToSum = double.Parse(Console.ReadLine());
            result += numberToSum;
        }
        Console.WriteLine(result);
    }
}
