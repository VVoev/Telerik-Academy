using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            double number = double.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new FormatException();
            }
            double sqrtNumber = Math.Sqrt(number);
            Console.WriteLine("{0:F3}", sqrtNumber);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");

        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
