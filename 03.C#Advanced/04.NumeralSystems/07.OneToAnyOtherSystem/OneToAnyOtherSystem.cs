using System;

class OneToAnyOtherSystem
{
    static void Main()
    {
        // The numeral systems must be between 2 and 16.
        int firstNumeralSystem = int.Parse(Console.ReadLine());
        string n = Console.ReadLine();
        int secondNumeralSystem = int.Parse(Console.ReadLine());

        // Conversion from first numeral system to decimal number.
        long decNum = FirstToDecimal(firstNumeralSystem, n);
        // Convert from decimal number to second numeral system.
        string secondBaseNumber = DecimalToSecond(decNum, secondNumeralSystem);

        // Put string in char array. Print final result in reverse order.
        char[] result = secondBaseNumber.ToCharArray();
        Array.Reverse(result);
        Console.WriteLine(result);
    }

    static long FirstToDecimal(int firstNumeralSystem, string n)
    {
        long decNum = 0;
        int index = 0;
        long baseCount = 1;
        int currentDigit = 0;
        while (index < n.Length)
        {
            if (char.IsDigit(n[n.Length - 1 - index]))
            {
                currentDigit = n[n.Length - 1 - index] - '0';
            }
            else
            {
                currentDigit = n[n.Length - 1 - index] - '7';
            }
            decNum += (long)(currentDigit * baseCount);
            baseCount *= firstNumeralSystem;
            index++;
        }

        return decNum;
    }

    static string DecimalToSecond(long firstBaseNumber, int step)
    {
        string secondBase = "";
        string[] hexa = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        while (firstBaseNumber > 0)
        {
            int digit = (int)(firstBaseNumber % step);
            firstBaseNumber /= step;
            secondBase += hexa[digit];
        }
        return secondBase;
    }
}
