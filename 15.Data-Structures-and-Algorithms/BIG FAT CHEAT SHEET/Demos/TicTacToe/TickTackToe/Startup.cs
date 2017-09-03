using System;
using System.Collections.Generic;
using System.Linq;

namespace TickTackToe
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = new int[3, 3];
            Console.WriteLine("Do you want to be first? (y/n)");
            bool isFirst = Console.ReadLine().ToLower().Contains("y");

            int end = isFirst ? 5 : 4;
            if (!isFirst)
            {
                matrix[1, 1] = 1;
            }

            int movesCount = 9;
            int winner;
            for (int i = 0; i < end; i++)
            {
                PrintField(matrix);
                Console.WriteLine("Enter cordinates: ");
                var userTurn = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int userRow = userTurn[0];
                int userCol = userTurn[1];

                if (matrix[userRow, userCol] != 0)
                {
                    Console.WriteLine("Invalid position");
                    i--;
                    continue;
                }

                matrix[userRow, userCol] = 2;
                movesCount--;

                if (movesCount == 0)
                {
                    break;
                }

                if (matrix[1, 1] == 0)
                {
                    matrix[1, 1] = 1;
                    movesCount--;
                }
                else
                {
                    var move = GetNextTurn(matrix, movesCount);
                    matrix[move.Item1, move.Item2] = 1;
                    movesCount--;
                }

                winner = CheckForWin(matrix);
                if (winner == 1)
                {
                    Console.WriteLine("You lose!");
                    return;
                }
                else if (winner == 2)
                {
                    Console.WriteLine("You win!");
                    return;
                }
            }

            Console.WriteLine("*****");
            PrintField(matrix);
            Console.WriteLine("*****");
            winner = CheckForWin(matrix);

            if (winner == 1)
            {
                Console.WriteLine("You lose!");
            }
            else if (winner == 2)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Draw!");
            }

            PrintField(matrix);
        }

        private static Tuple<int, int> GetNextTurn(int[,] matrix, int movesCount)
        {
            int minLosses = int.MaxValue;
            int maxWins = int.MinValue;
            int maxDraws = int.MinValue;
            int bestRow = -5;
            int bestCol = -5;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = 1;

                        int h = CheckForWin(matrix);

                        if (h == 1)
                        {
                            return new Tuple<int, int>(i, j);
                        }

                        matrix[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = 2;

                        int c = CheckForWin(matrix);

                        if (c == 2)
                        {
                            return new Tuple<int, int>(i, j);
                        }

                        matrix[i, j] = 0;
                    }
                }
            }


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = 1;
                        int currentLosses = 0;
                        int currentDraws = 0;
                        int currentWins = 0;
                        GetOptimalMoves(matrix, movesCount, false, ref currentWins, ref currentDraws, ref currentLosses);
                        if (currentLosses < minLosses)
                        {
                            minLosses = currentLosses;
                            maxWins = currentWins;
                            maxDraws = currentDraws;
                            bestCol = j;
                            bestRow = i;
                        }
                        else if (currentLosses == minLosses)
                        {
                            if (currentWins * 2 + currentDraws > maxWins * 2 + maxDraws)
                            {
                                minLosses = currentLosses;
                                maxWins = currentWins;
                                maxDraws = currentDraws;
                                bestCol = j;
                                bestRow = i;
                            }
                        }

                        matrix[i, j] = 0;
                    }
                }
            }

            return new Tuple<int, int>(bestRow, bestCol);
        }

        public static void GetOptimalMoves(int[,] matrix, int movesCount, bool turn, ref int wins, ref int draws, ref int losses)
        {
            if (movesCount == 0)
            {
                int c = CheckForWin(matrix);
                if (c == 0)
                {
                    draws++;
                }
                else if (c == 1)
                {
                    wins++;
                }
                else
                {
                    losses++;
                }

                return;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = turn ? 1 : 2;

                        int c = CheckForWin(matrix);
                        if (c != 0)
                        {
                            if (turn)
                            {
                                wins++;
                            }
                            else
                            {
                                losses++;
                            }

                            matrix[i, j] = 0;
                            return;
                        }

                        GetOptimalMoves(matrix, movesCount - 1, !turn, ref wins, ref draws, ref losses);
                        matrix[i, j] = 0;
                    }
                }
            }
        }

        private static int CheckForWin(int[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                if (matrix[i, 0] != 0 && matrix[i, 0] == matrix[i, 1] && matrix[i, 1] == matrix[i, 2])
                {
                    return matrix[i, 0];
                }

                if (matrix[0, i] != 0 && matrix[0, i] == matrix[1, i] && matrix[1, i] == matrix[2, i])
                {
                    return matrix[0, i];
                }
            }

            if (matrix[0, 0] != 0 && matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2])
            {
                return matrix[0, 0];
            }

            if (matrix[0, 2] != 0 && matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0])
            {
                return matrix[0, 2];
            }

            return 0;
        }

        public static void PrintField(int[,] field)
        {
            Console.WriteLine("+ + + + +");
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.Write("+ ");
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    Console.Write(field[i, k] + " ");
                }
                Console.Write("+");
                Console.WriteLine();
            }

            Console.WriteLine("+ + + + +");
        }

        public static int[,] CopyMatrix(int[,] field)
        {
            int[,] result = new int[3, 3];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    result[i, k] = field[i, k];
                }
            }

            return result;
        }
    }
}