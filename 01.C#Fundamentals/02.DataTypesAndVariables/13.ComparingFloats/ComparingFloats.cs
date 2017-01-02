using System;

class ComparingFloats
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        const double eps = 0.000001;

        double result = Math.Abs(firstNumber - secondNumber);
        bool equals = result < eps;

        if (equals == true)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
        
    }
}
