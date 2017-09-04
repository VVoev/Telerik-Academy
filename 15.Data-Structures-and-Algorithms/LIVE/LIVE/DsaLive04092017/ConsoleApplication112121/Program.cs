namespace ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        public static SortedSet<string> results = new SortedSet<string>();
        public static SortedSet<string> resultAsNumber = new SortedSet<string>();
        public static char[] map = new char[] { '+', '-', '*' };

        public static void Solve(int index)
        {
            if (index == map.Length)
            {
                results.Add(new string(map));
                var suma = 0;
                for (int i = 0; i < digitsToJunglirane.Length-1; i++)
                {
                    var mapAsneshto = map[i];
                    if(mapAsneshto == '+')
                    {
                        suma += digitsToJunglirane[i] + digitsToJunglirane[i + 1];
                    }
                    else if(mapAsneshto == '-')
                    {
                        suma += digitsToJunglirane[i] - digitsToJunglirane[i + 1];
                    }
                    else
                    {
                        suma += digitsToJunglirane[i] * digitsToJunglirane[i + 1];
                    }
                }
                if(suma == neededNumber)
                {
                    Console.WriteLine("Da");
                }
                return;
            }
            else
            {
                map[index] = '+';
                Solve(index + 1);
                map[index] = '-';
                Solve(index + 1);
                map[index] = '*';
                Solve(index + 1);
            }
        }

        static string digitsToJunglirane = Console.ReadLine();
        static long neededNumber = long.Parse(Console.ReadLine());

        public static void Main()
        {
            Solve(0);
            Console.WriteLine();
        }
    }
}