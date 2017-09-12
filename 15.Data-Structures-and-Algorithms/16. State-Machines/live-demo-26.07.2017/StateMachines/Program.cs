using System;
using System.Collections.Generic;

namespace StateMachines
{
    class Program
    {
        static double ToCloserInfinity(double x)
        {
            return x < 0
                ? Math.Floor(x)
                : Math.Ceiling(x);
        }

        static void Main(string[] args)
        {
            var programCode = "";

            if (args.Length < 1)
            {
                var lineList = new List<string>();

                while (true)
                {
                    var line = Console.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    lineList.Add(line);
                }

                programCode = string.Join("\n", lineList);
            }
            else
            {
                var filename = args[0];
                programCode = System.IO.File.ReadAllText(filename);
            }

            var program = new Expression(programCode);
            program.Eval();
        }
    }
}
