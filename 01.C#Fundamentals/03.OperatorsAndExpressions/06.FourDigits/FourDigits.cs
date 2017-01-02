using System;

class FourDigits
{
    static void Main()
    {
        string fourDigitNumber = Console.ReadLine();

        Console.WriteLine((int.Parse(fourDigitNumber[0].ToString()))
                        + (int.Parse(fourDigitNumber[1].ToString()))
                        + (int.Parse(fourDigitNumber[2].ToString()))
                        + (int.Parse(fourDigitNumber[3].ToString())));
        Console.WriteLine("{0}{1}{2}{3}", fourDigitNumber[3], fourDigitNumber[2], fourDigitNumber[1], fourDigitNumber[0]);
        Console.WriteLine("{0}{1}{2}{3}", fourDigitNumber[3], fourDigitNumber[0], fourDigitNumber[1], fourDigitNumber[2]);
        Console.WriteLine("{0}{1}{2}{3}", fourDigitNumber[0], fourDigitNumber[2], fourDigitNumber[1], fourDigitNumber[3]);
    }
}
