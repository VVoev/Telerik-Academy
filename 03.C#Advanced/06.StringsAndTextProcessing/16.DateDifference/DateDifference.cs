using System;

class DateDifference
{
    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();
        string format = "dd.MM.yyyy";
        DateTime firstDate = DateTime.ParseExact(first, format, null);
        DateTime secondDate = DateTime.ParseExact(second, format, null);
        TimeSpan difference = firstDate - secondDate;
        var days = difference.TotalDays;
        Console.WriteLine("Distance {0} days",Math.Abs(days));
    }
}
