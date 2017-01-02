using System;

class DecimalToBinary
{
    static void Main()
    {
        int decNumber = int.Parse(Console.ReadLine());
        string binary = "";

        ConvertDecimalToBinaryNumber(ref decNumber, ref binary);
        Console.WriteLine("{0}", binary.ToString()/*.PadLeft(32, '0')*/);
    }

    static void ConvertDecimalToBinaryNumber(ref int decNumber, ref string binary)
    {
        while (decNumber > 0)
        {
            int dividedBy2 = (int)(decNumber % 2);
            decNumber /= 2;
            binary = dividedBy2 + binary;
        }
    }
}
