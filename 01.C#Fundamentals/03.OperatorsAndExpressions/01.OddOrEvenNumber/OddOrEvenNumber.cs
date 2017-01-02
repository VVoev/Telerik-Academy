using System;

class OddOrEvenNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int check = Math.Abs(number);
        if (check % 2 == 1)
        {
            Console.WriteLine("odd " + number);
        }
        else
        {
            Console.WriteLine("even " + number);
        }
    }
}
