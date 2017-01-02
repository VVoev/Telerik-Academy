namespace _03.RangeExceptions
{
    using System;

    class ExceptionTest
    {
        static void Main()
        { 
            GetValueInt();


            GetValueDateTime();
    }

    private static void GetValueDateTime()
    {
        try
        {
            DateTime start = new DateTime(1980, 1, 1);
            DateTime end = new DateTime(2013, 12, 31);

            DateTime x = new DateTime(2016, 06, 18);
            if (x < start || x > end)
            {
                throw new InvalidRangeException<DateTime>(start, end);
            }
        }
        catch (InvalidRangeException<DateTime> dtex)
        {
            Console.WriteLine(String.Format("{0} ({1}, {2}) {3}", dtex.Message, dtex.Start.Year, dtex.End.Year, dtex.StackTrace));
        }
    }

    private static void GetValueInt()
    {
        try
        {
            int start = 1;
            int end = 100;

            int x = 152;
            if (x < start || x > end)
            {
                throw new InvalidRangeException<int>(start, end);
            }
        }
        catch (InvalidRangeException<int> dtex)
        {
            Console.WriteLine(String.Format("{0} ({1}, {2})", dtex.Message, dtex.Start, dtex.End, dtex.StackTrace));
        }
    }
}
}
