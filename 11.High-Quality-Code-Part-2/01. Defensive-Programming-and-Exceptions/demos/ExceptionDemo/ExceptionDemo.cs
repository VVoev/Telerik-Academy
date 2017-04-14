using System;

namespace ExceptionDemo
{
    public class ExceptionDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a Number");
            string b = Console.ReadLine();

            try
            {
                var sum = Int32.Parse(b);
                Console.WriteLine("Valid Parse");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Format");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is too big to fit in INT structure");
            }
            finally
            {
                Console.WriteLine("Program End ");
            }
        }
    }
}
