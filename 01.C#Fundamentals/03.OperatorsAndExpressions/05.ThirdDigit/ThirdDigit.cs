using System;

class ThirdDigit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool thirdDigit = false;
        int count = 0;
        int third = 0;
        while (number > 0)
        {
            number /= 10;
            count++;
            if (number % 10 == 7 && count == 2)
            {
                thirdDigit = true;
                break;
            }
            else if (number % 10 != 7 && count == 2)
            {
                third = number % 10;
            }
        }
        if (thirdDigit)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false {0}", third);
        }
    }
}
