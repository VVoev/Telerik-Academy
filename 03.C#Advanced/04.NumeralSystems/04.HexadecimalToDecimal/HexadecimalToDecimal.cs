using System;

class HexaDecimalToDecimal
{
    static void Main()
    {
        string hexaNumber = Console.ReadLine().ToUpper();
        long convertedNumber = 0;
        int power = 16;
        convertedNumber = ConvertHexadecimalToDecimal(hexaNumber, power);
        Console.WriteLine(convertedNumber);
    }

    static long ConvertHexadecimalToDecimal(string hexaNumber, int power)
    {
        int decimalValue;
        long result = 0; ;
        for (int i = 0; i < hexaNumber.Length; i++)
        {
            decimalValue = CalculateDecimalValue(hexaNumber, i);
            result += (long)((Math.Pow(power, hexaNumber.Length - i - 1)) * decimalValue);
        }
        return result;
    }

    static int CalculateDecimalValue(string hexaNumber, int i)
    {
        int decValue;
        if (hexaNumber[i] >= 'A' && hexaNumber[i] <= 'F')
        {
            decValue = (hexaNumber[i] - '7');
        }
        else
        {
            decValue = hexaNumber[i] - '0';
        }

        return decValue;
    }
}
