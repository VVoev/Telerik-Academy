using System;

class HexaDecimalToDecimal
{
    static void Main()
    {
        string hexaNumber = Console.ReadLine().ToUpper();
        string[] hexa = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        int decValue = 0;
        long result = 0;
        int power = 16;
        for (int i = 0; i < hexaNumber.Length; i++)
        {
            decValue = CalculateDecimalValue(hexaNumber, i);
            result += (long)((Math.Pow(power, hexaNumber.Length - i - 1)) * decValue);
        }
        Console.WriteLine(result);
    }

    private static int CalculateDecimalValue(string hexaNumber, int i)
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
