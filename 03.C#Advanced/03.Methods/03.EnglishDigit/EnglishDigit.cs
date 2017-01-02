using System;

class EnglishDigit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int lastDigit = number % 10;
        Console.WriteLine(DigitAsWord(lastDigit));
    }
    static string DigitAsWord(int digit)
    {
        string[] digitsAsWord = new string[] 
        { "zero",
          "one",
          "two",
          "three",
          "four",
          "five",
          "six",
          "seven",
          "eight",
          "nine" };
        return digitsAsWord[digit];
    }
}
