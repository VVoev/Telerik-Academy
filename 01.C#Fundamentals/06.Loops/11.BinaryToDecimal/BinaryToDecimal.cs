    using System;

    class BinaryToDecimal
    {
        static void Main()
        {
            string binaryNumber = Console.ReadLine().PadLeft(32, '0');
            long result = 0;
            int power = 2;
            result = ConvertBinaryToDecimal(binaryNumber, result, power);
            Console.WriteLine(result);
        }

        static long ConvertBinaryToDecimal(string binaryNumber, long result, int power)
        {
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
    }
