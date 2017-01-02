using System;

class CompareCharArrays
{
    static void Main()
    {
        char[] firstArray = Console.ReadLine().ToCharArray();
        char[] secondArray = Console.ReadLine().ToCharArray();

        for (int i = 0; i < Math.Min(firstArray.Length, secondArray.Length); i++)
        {
            if ((char)firstArray[i] < (char)secondArray[i])
            {
                Console.WriteLine("<");
                return;
            }
            else if ((char)secondArray[i] < (char)firstArray[i])
            {
                Console.WriteLine(">");
                return;
            }
        }
        if (firstArray.Length < secondArray.Length)
        {
            Console.WriteLine("<");
        }
        else if (firstArray.Length > secondArray.Length)
        {
            Console.WriteLine(">");
        }
        else
        {
            Console.WriteLine("=");
        }
    }
}
