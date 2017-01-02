using System;
using System.Globalization;

class Age
{
    static void Main()
    {
        string format = "MM.dd.yyyy";
        string dateofBirth = Console.ReadLine();
        DateTime myBirthday = DateTime.ParseExact(dateofBirth, format, null);
        DateTime todaysDate = DateTime.Now;
        int myAge = 0;
        if (todaysDate.Year == myBirthday.Year)
        {
            myAge = 0;
        }
        else if (todaysDate.Month < myBirthday.Month)
        {
            myAge = todaysDate.Year - myBirthday.Year - 1;
        }
        else
        {
            myAge = todaysDate.Year - myBirthday.Year;
        }
        Console.WriteLine(myAge);
        Console.WriteLine(myAge + 10);
    }
}
