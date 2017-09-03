using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsTime
{
    public class Program
    {
        public static void Main()
        {
            var start = Console.ReadLine();
            var target = Console.ReadLine();

            var result = GetMatrix(start, target);
            //Console.WriteLine(result);
        }

        public static double[,] GetMatrix(string start, string target)
        {
            var matrix = new double[start.Length + 1, target.Length + 1];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = (start[i - 1] == '0' ? 0.9 : 0.8) + matrix[i - 1, 0];
            }

            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                matrix[0, i] = (target[i - 1] == '0' ? 1.1 : 1.2) + matrix[0, i - 1];
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    double changeCost = (target[col - 1] == start[row - 1] ? 0 : 1) + matrix[row - 1, col - 1];
                    double deleteCost = (start[row - 1] == '0' ? 0.9 : 0.8) + matrix[row - 1, col];
                    double addCost = (target[col - 1] == '0' ? 1.1 : 1.2) + matrix[row, col - 1];

                    var min = FindMin(changeCost, deleteCost, addCost);
                    matrix[row, col] = min;
                }
            }

            Console.WriteLine(matrix[start.Length, target.Length]);
            return matrix;
        }

        public static double FindMin(double first, double second, double third)
        {
            var min = Math.Min(first, second);

            return Math.Min(min, third);
        }
    }
}