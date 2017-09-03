using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLabyrinth
{
    public class Room
    {
        public Room(int level, int row, int col, int steps)
        {
            this.Level = level;
            this.Row = row;
            this.Col = col;
            this.Steps = steps;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Level { get; set; }

        public int Steps { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var startRoom = new Room(line[0], line[1], line[2], 0);

            line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var building = new char[line[0], line[1], line[2]];

            var dirs = new int[][]
            {
                new int[]{1,0},
                new int[]{-1,0},
                new int[]{0,1},
                new int[]{0,-1},
            };

            for (int i = 0; i < building.GetLength(0); i++)
            {
                for (int j = 0; j < building.GetLength(1); j++)
                {
                    var row = Console.ReadLine();
                    for (int k = 0; k < row.Length; k++)
                    {
                        building[i, j, k] = row[k];
                    }
                }
            }

            var visited = new bool[line[0], line[1], line[2]];
            var queue = new Queue<Room>();
            queue.Enqueue(startRoom);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                visited[current.Level, current.Row, current.Col] = true;

                for (int i = 0; i < dirs.Length; i++)
                {
                    var nextRow = dirs[i][0] + current.Row;
                    var nextCol = dirs[i][1] + current.Col;

                    if (building[current.Level, current.Row, current.Col] == 'U')
                    {
                        var nextLevel = current.Level + 1;
                        if (nextLevel >= building.GetLength(0))
                        {
                            Console.WriteLine(current.Steps + 1);
                            return;
                        }

                        if (building[nextLevel, current.Row, current.Col] != '#' && !visited[nextLevel, current.Row, current.Col])
                        {
                            visited[nextLevel, current.Row, current.Col] = true;
                            queue.Enqueue(new Room(nextLevel, current.Row, current.Col, current.Steps + 1));
                        }
                    }
                    else if (building[current.Level, current.Row, current.Col] == 'D')
                    {
                        var nextLevel = current.Level - 1;
                        if (nextLevel < 0)
                        {
                            Console.WriteLine(current.Steps + 1);
                            return;
                        }

                        if (building[nextLevel, current.Row, current.Col] != '#' && !visited[nextLevel, current.Row, current.Col])
                        {
                            visited[nextLevel, current.Row, current.Col] = true;
                            queue.Enqueue(new Room(nextLevel, current.Row, current.Col, current.Steps + 1));
                        }
                    }

                    if (!IsInRange(nextRow, building.GetLength(1)) || !IsInRange(nextCol, building.GetLength(2)) || building[current.Level, nextRow, nextCol] == '#'  || visited[current.Level, nextRow, nextCol])
                    {
                        continue;
                    }
                    else
                    {
                        visited[current.Level, nextRow, nextCol] = true;
                        queue.Enqueue(new Room(current.Level, nextRow, nextCol, current.Steps + 1));
                    }
                }
            }

            Console.WriteLine(-1);
        }

        public static bool IsInRange(int current, int max)
        {
            return current >= 0 && current < max;
        }
    }
}
