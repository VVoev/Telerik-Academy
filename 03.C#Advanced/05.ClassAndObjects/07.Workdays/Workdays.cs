using System;

class Workdays
{
    static void Main()
    {
        DateTime startOfYear = new DateTime(2016, 01, 01);
        DateTime endOfYear = new DateTime(2016, 12, 31);

        double alldays = (endOfYear - startOfYear).TotalDays;
        double workdays = CountWorkdays(startOfYear, alldays);
        Console.WriteLine(workdays);
    }

    static double CountWorkdays(DateTime startOfYear, double alldays)
    {
        double workdays = 0;
        for (int i = 0; i < alldays; i++)
        {
            DateTime currentDay = startOfYear.AddDays(i);
            string currentDate = Convert.ToString(startOfYear.AddDays(i).DayOfWeek);

            // The check works only for holidays in 2016.
            bool holidays = CheckIsDayHoliday(currentDay);
            if (holidays)
            {
                continue;
            }
            if (currentDate != "Sunday" && currentDate != "Saturday")
            {
                workdays++;
            }

        }

        return workdays;
    }

    static bool CheckIsDayHoliday(DateTime currentDay)
    {
        if ((currentDay.Day == 1 && currentDay.Month == 1)  ||
            (currentDay.Day == 3 && currentDay.Month == 3)  ||
            (currentDay.Day == 29 && currentDay.Month == 4) ||
            (currentDay.Day == 2 && currentDay.Month == 5)  ||
            (currentDay.Day == 6 && currentDay.Month == 5)  ||
            (currentDay.Day == 24 && currentDay.Month == 5) ||
            (currentDay.Day == 6 && currentDay.Month == 9)  ||
            (currentDay.Day == 22 && currentDay.Month == 9) ||
            (currentDay.Day == 26 && currentDay.Month == 12))

        {
            return true;
        }
        return false;
    }
}
