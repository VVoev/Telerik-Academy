using System;

class ReverseNumber
{
    static void Main()
    {
        string decimalNumber = Console.ReadLine();

        string reversedNumber = Reverse(decimalNumber);
        Console.WriteLine(reversedNumber);
    }
    static string Reverse(string number)
    {
        string result = string.Empty;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            result += number[i];
        }
        return result; 
    }
}

