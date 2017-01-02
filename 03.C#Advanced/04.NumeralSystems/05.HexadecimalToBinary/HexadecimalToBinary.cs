using System;

class HexaDecimalToBinary
{
    static void Main()
    {
        string hexaNumber = Console.ReadLine().ToUpper();
        long convertedNumber = 0;
        int power = 16;
        // From 16 numeral to 10 numeral.
        convertedNumber = ConvertHexadecimalToDecimal(hexaNumber, power);

        // From 10 numeral to binary.
        string binaryNumber = ConvertDecimalToBinaryNumber(ref convertedNumber);
        Console.WriteLine(binaryNumber);
    }
    static string ConvertDecimalToBinaryNumber(ref long convertedNumber)
    {
        string binary = "";
        while (convertedNumber > 0)
        {
            int dividedBy2 = (int)(convertedNumber % 2);
            convertedNumber /= 2;
            binary = dividedBy2 + binary;
        }
        return binary;
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
