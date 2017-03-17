using System;
using System.Linq;

namespace Methods
{
    public class Methods
    {
       public static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException($@"Sides of triangle should be positive");
            }

            double squareTriangle = (sideA + sideB + sideC) / 2;
            double areaTriangle = Math.Sqrt(squareTriangle * (squareTriangle - sideA) * (squareTriangle - sideB) * (squareTriangle - sideC));
            return areaTriangle;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new Exception("The data should be a digit,please provide correct data");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new Exception("Number of parameters should be at least one");
            }

            var maxElement = elements.Max();
            return maxElement;
        }

        public static void PrintAsNumber(double number, Format format)
        {
            switch (format)
            {
                case Format.AlignRight: Console.WriteLine("{0:f2}", number);
                    break;
                case Format.Percent: Console.WriteLine("{0:f2}", number);
                    break;
                case Format.FloatingPoint: Console.WriteLine("{0:f2}", number);
                    break;
                default: throw new Exception("Invalid Format");
            }
        }

        private static double CalcDistance(double firstPointX1, double firstPointY1, double secondPointX2, double secondPointY2, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = firstPointY1 == secondPointY2;
            isVertical = firstPointX1 == secondPointX2;

            double distance = Math.Sqrt(((secondPointX2 - firstPointX1) * (secondPointX2 - firstPointX1)) +
                ((secondPointY2 - firstPointY1) * (secondPointY2 - firstPointY1)));

            return distance;
        }

        private static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, Format.AlignRight);
            PrintAsNumber(0.75, Format.Percent);
            PrintAsNumber(2.30, Format.FloatingPoint);

            bool horizontal;
            bool vertical;

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student petar = new Student("Petar", "Kirilov", new DateTime(1985, 7, 17), Town.Plovdiv, "N/A");
            Student stela = new Student("Stela", "Ivanova", new DateTime(1980, 02, 23), Town.StaraZagora, "Specialist in C++");

            Console.WriteLine(stela.IsOlderThan(petar));
        }
    }
}
