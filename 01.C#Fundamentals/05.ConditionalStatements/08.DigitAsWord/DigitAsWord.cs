using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DigitAsWord
{
    static void Main()
    {
        string[] digit = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string enterDigit = Console.ReadLine();

        switch (enterDigit)
        {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
                int num = int.Parse(enterDigit.ToString());
                Console.WriteLine(digit[num]);
                break;
            default:
                Console.WriteLine("not a digit");
                break;
        }
    }
}
