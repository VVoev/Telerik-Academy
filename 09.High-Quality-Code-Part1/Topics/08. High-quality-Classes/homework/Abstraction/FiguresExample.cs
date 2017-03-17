using System;

namespace Abstraction
{
    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine(circle.ToString());
            Console.WriteLine($@"I am a circle. My perimeter is {circle.CalcPerimeter()} . My surface is {circle.CalcSurface():f2}.");

            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(rect.ToString());
            Console.WriteLine($@"I am a rectangle. My perimeter is {rect.CalcPerimeter()}. My surface is {rect.CalcSurface()}.");
        }
    }
}
