using System;
using System.Collections.Generic;

namespace _3DLabyrinth
{
    class Labyrinth
    {
        static char[,,] cube;
        static long[,,] visited;

        //check zero

        static void BFS(Coordinates start)
        {
            long count = 0;
            Queue<Coordinates> queue = new Queue<Coordinates>();
            queue.Enqueue(start);
            visited[start.Level, start.Row, start.Col] = count;

            while (queue.Count != 0)
            {
                var coords = queue.Dequeue();
                count = visited[coords.Level, coords.Row, coords.Col];

                if (cube[coords.Level, coords.Row, coords.Col] == 'U')
                {
                    if (coords.Level + 1 >= cube.GetLength(0))
                    {
                        Console.WriteLine(count + 1);
                        break;
                    }

                    if (visited[coords.Level + 1, coords.Row, coords.Col] == 0 && cube[coords.Level + 1, coords.Row, coords.Col] != '#')
                    {
                        Coordinates next = new Coordinates(coords.Level + 1, coords.Row, coords.Col);
                        visited[next.Level, next.Row, next.Col] = count + 1;
                        queue.Enqueue(next);
                    }
                }

                if (cube[coords.Level, coords.Row, coords.Col] == 'D')
                {
                    if (coords.Level - 1 < 0)
                    {
                        Console.WriteLine(count + 1);
                        break;
                    }

                    if (visited[coords.Level - 1, coords.Row, coords.Col] == 0 && cube[coords.Level - 1, coords.Row, coords.Col] != '#')
                    {
                        Coordinates next = new Coordinates(coords.Level - 1, coords.Row, coords.Col);
                        visited[next.Level, next.Row, next.Col] = count + 1;
                        queue.Enqueue(next);
                    }
                }

                if (coords.Row - 1 >= 0 && cube[coords.Level, coords.Row - 1, coords.Col] != '#')
                {
                    if (visited[coords.Level, coords.Row - 1, coords.Col] == 0)
                    {
                        Coordinates next = new Coordinates(coords.Level, coords.Row - 1, coords.Col);
                        visited[next.Level, next.Row, next.Col] = count + 1;
                        queue.Enqueue(next);
                    }
                }

                if (coords.Row + 1 < cube.GetLength(1) && cube[coords.Level, coords.Row + 1, coords.Col] != '#')
                {
                    if (visited[coords.Level, coords.Row + 1, coords.Col] == 0)
                    {
                        Coordinates next = new Coordinates(coords.Level, coords.Row + 1, coords.Col);
                        visited[next.Level, next.Row, next.Col] = count + 1;
                        queue.Enqueue(next);
                    }
                }

                if (coords.Col - 1 >= 0 && cube[coords.Level, coords.Row, coords.Col - 1] != '#')
                {
                    if (visited[coords.Level, coords.Row, coords.Col - 1] == 0)
                    {
                        Coordinates next = new Coordinates(coords.Level, coords.Row, coords.Col - 1);
                        visited[next.Level, next.Row, next.Col] = count + 1;
                        queue.Enqueue(next);
                    }
                }

                if (coords.Col + 1 < cube.GetLength(2) && cube[coords.Level, coords.Row, coords.Col + 1] != '#')
                {
                    if (visited[coords.Level, coords.Row, coords.Col + 1] == 0)
                    {
                        Coordinates next = new Coordinates(coords.Level, coords.Row, coords.Col + 1);
                        visited[next.Level, next.Row, next.Col] = count + 1;
                        queue.Enqueue(next);
                    }
                }
            }
        }

        static void Main()
        {
            string[] startDimensions = Console.ReadLine().Split(' ');

            int startLevel = int.Parse(startDimensions[0]);
            int startRow = int.Parse(startDimensions[1]);
            int startCol = int.Parse(startDimensions[2]);

            string[] dimensions = Console.ReadLine().Split(' ');

            int levels = int.Parse(dimensions[0]);
            int rows = int.Parse(dimensions[1]);
            int cols = int.Parse(dimensions[2]);

            cube = new char[levels, rows, cols];
            visited = new long[levels, rows, cols];

            for (int i = 0; i < levels; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    //can be optimized
                    string currentRow = Console.ReadLine();

                    for (int k = 0; k < currentRow.Length; k++)
                    {
                        cube[i, j, k] = currentRow[k];
                    }
                }
            }

            Coordinates start = new Coordinates(startLevel, startRow, startCol);

            BFS(start);
        }
    }

    public class Coordinates
    {
        public int Level { get; private set; }
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Coordinates(int level, int row, int col)
        {
            this.Level = level;
            this.Row = row;
            this.Col = col;
        }
    }
}