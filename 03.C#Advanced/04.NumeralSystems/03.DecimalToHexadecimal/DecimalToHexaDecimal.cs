using System;

class DecimalToHexaDecimal
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        string[] hexa = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        string hexaDecimal = "";

        ConvertDecimalToHexaDecimal(ref decimalNumber, hexa, ref hexaDecimal);
        char[] hexaArray = hexaDecimal.ToCharArray();
        Array.Reverse(hexaArray);
        Console.WriteLine(new string(hexaArray));
    }

    static void ConvertDecimalToHexaDecimal(ref long decimalNumber, string[] hexa, ref string hexaDecimal)
    {
        while (decimalNumber > 0)
        {
            int dividedBy16 = (int)(decimalNumber % 16);
            decimalNumber /= 16;
            hexaDecimal += hexa[dividedBy16];
        }
    }
}

