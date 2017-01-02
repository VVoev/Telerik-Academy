namespace _01.Shapes
{
    using Abstract;
    using Figures;
    using System;
    using System.Collections.Generic;

    class ShapesTest
    {
        static void Main()
        {
            int numberOfFigures = 15;
            double width, height;
            Random rnd = new Random();
            var figures = new List<Shape>();

            for (int i = 0; i < numberOfFigures; i++)
            {
                width = rnd.Next(1, 150);
                height = rnd.Next(1, 75);
                if (i < 5)
                {
                    var currentTriangle = new Triangle(width, height);
                    figures.Add(currentTriangle);
                }
                else if (i < 10)
                {
                    var currentRectangle = new Rectangle(width, height);
                    figures.Add(currentRectangle);
                }
                else
                {
                    var squareSide = (width + height) / 2;
                    var currentSquare = new Square(squareSide);
                    figures.Add(currentSquare);
                }
            }
            figures.ForEach(x => Console.WriteLine(x.ToString() + " cm."));
        }
    }
}
