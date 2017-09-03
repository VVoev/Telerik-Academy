using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ColoredLines
{
    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split(' ');
            int rows = int.Parse(line[0]);
            int cols = int.Parse(line[1]);

            var drawing = new char[rows, cols];
            ReadDrawing(drawing);

            int result = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    char currentSymbol = drawing[i, j];

                    if (currentSymbol == 'B')
                    {
                        if ((i > 0 && drawing[i - 1, j] != 'B' && drawing[i - 1, j] != 'G'))
                        {
                            result++;
                        }
                        else if (i == 0)
                        {
                            result++;
                        }
                    }
                    else if (currentSymbol == 'R')
                    {
                        if (j > 0 && drawing[i, j - 1] != 'R' && drawing[i, j - 1] != 'G')
                        {
                            result++;
                        }
                        else if (j == 0)
                        {
                            result++;
                        }
                    }
                    else if (currentSymbol == 'G')
                    {
                        if (i > 0 && drawing[i - 1, j] != 'B' && drawing[i - 1, j] != 'G')
                        {
                            result++;
                        }
                        if (j > 0 && drawing[i, j - 1] != 'R' && drawing[i, j - 1] != 'G')
                        {
                            result++;
                        }
                        if (j == 0)
                        {
                            result++;
                        }
                        if (i == 0)
                        {
                            result++;
                        }
                        
                    }
                }
            }

            Console.WriteLine(result);
        }

        public static void ReadDrawing(char[,] drawing)
        {
            for (int i = 0; i < drawing.GetLength(0); i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < drawing.GetLength(1); j++)
                {
                    drawing[i, j] = line[j];
                }
            }
        }
    }
}
