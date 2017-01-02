using System;

class IntervalBy5Count
{
    static void Main()
    {
        int startNumber = int.Parse(Console.ReadLine());
        int endNumber = int.Parse(Console.ReadLine());
        int intervalCount = 0;
        for (int i = startNumber + 1; i < endNumber; i++)
        {
            if (i % 5 == 0)
            {
                intervalCount++;
            }
        }
        Console.WriteLine(intervalCount);
    }
}
