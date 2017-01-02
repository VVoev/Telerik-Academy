using System;

class BinaryToHexadecimal
{
    static void Main()
    {
        string binary = Console.ReadLine();
        long decimalNumber = ConvertBinaryToDecimal(binary, 2);
        string hexadecimal = ConvertDecimalToHexaDecimal(ref decimalNumber);
        char[] hexaArray = hexadecimal.ToCharArray();
        Array.Reverse(hexaArray);
        Console.WriteLine(hexaArray);
    }

    static long ConvertBinaryToDecimal(string binaryNumber, int power)
    {
        long result = 0;
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            if (binaryNumber[binaryNumber.Length - i - 1] == '0')
            {
                result += 0;
            }
            else
            {
                result += (long)(1 * Math.Pow(power, i));
            }
        }

        return result;
    }

    static string ConvertDecimalToHexaDecimal(ref long decimalNumber)
    {
        string[] hexa = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        string hexaDecimal = "";
        while (decimalNumber > 0)
        {
            int dividedBy16 = (int)(decimalNumber % 16);
            decimalNumber /= 16;
            hexaDecimal += hexa[dividedBy16];
        }
        return hexaDecimal;
    }
}
