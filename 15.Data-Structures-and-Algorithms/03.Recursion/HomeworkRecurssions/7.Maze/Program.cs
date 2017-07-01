namespace _07.Maze
{
    using System;

    class Program
    {
        private static string[,] maze;
        static void Main(string[] args)
        {
            maze = new string[,]
            {
                {"*", " ", " ", " ", " ", "e"},
                {" ", "x", "x", " ", "x", " "},
                {" ", " ", "x", " ", "x", " "},
                {" ", "x", " ", " ", " ", " "},
                {" ", "x", " ", "x", " ", " "},
                {" ", " ", " ", "x", " ", " "},
            };


            var startPosition = new Cell<int>(-1, -1);
            FindStartPosition(startPosition, maze);

            try
            {
                FindWay(startPosition.Row, startPosition.Col);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("There is no start position '*' provided in the maze");
            }

        }

        private static void FindWay(int startRow, int startCol)
        {
            if (startRow < 0 || startCol < 0 ||
                startRow >= maze.GetLength(0) || startCol >= maze.GetLength(1))
            {
                return;
            }

            if (maze[startRow, startCol] == "x" || maze[startRow, startCol] == "o")
            {
                return;
            }

            if (maze[startRow, startCol] == "e")
            {
                PrintMaze(maze);
                Console.WriteLine();
                return;
            }

            // Backtracking
            maze[startRow, startCol] = "o";

            // up
            FindWay(startRow - 1, startCol);

            // right
            FindWay(startRow, startCol + 1);

            // down
            FindWay(startRow + 1, startCol);

            // left
            FindWay(startRow, startCol - 1);

            // Backtracking
            maze[startRow, startCol] = " ";
        }

        private static void PrintMaze(string[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == "o" || maze[i, j] == "e")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (maze[i, j] == "x")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(maze[i, j].ToString().PadLeft(2, ' '));
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void FindStartPosition(Cell<int> startCell, string[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row, col] == "*")
                    {
                        startCell.Row = row;
                        startCell.Col = col;
                    }

                }
            }
        }
    }

    public class Cell<T>
    {
        public T Row { get; set; }
        public T Col { get; set; }

        public Cell(T row, T col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
