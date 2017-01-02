using System;

class BinaryShort
{
    static void Main()
    {
        // The number must be between -32768 and 32767.
        short decNumber = short.Parse(Console.ReadLine());

        // Convert short number in binary.
        string binaryNumber = ConvertShortDecimalToBinaryNumber(decNumber);

        // Print final binary number with two cases. Number is negative(the most left bit is always '1') or positive.
        PrintBinaryShortNumber(decNumber, binaryNumber);
    }

    static void PrintBinaryShortNumber(short decNumber, string binaryNumber)
    {
        if (decNumber < 0)
        {
            binaryNumber = "1" + binaryNumber.ToString()
                                             .PadLeft(15, '0');
            Console.WriteLine("{0}", binaryNumber.ToString());
        }
        else
        {
            Console.WriteLine("{0}", binaryNumber.ToString()
                                                 .PadLeft(16, '0'));
        }
    }

    static string ConvertShortDecimalToBinaryNumber(short number)
    {
        string binary = string.Empty;
        // If number is negative the binary number sum with max.Value  + 1.
        number = CheckNegativeNumber(number);
        while (number > 0)
        {
            int dividedBy2 = (int)(number % 2);
            binary = dividedBy2 + binary;
            number /= 2;
        }
        return binary;
    }

    static short CheckNegativeNumber(short number)
    {
        if (number < 0)
        {
            number = (short)(number + short.MaxValue + 1);
        }

        return number;
    }
}
