using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachines
{
    class Startup
    {
        static void Main()
        {
            RunProgramConsole();
           // RunProgramFromFile();
        }

        public static void RunProgramConsole()
        {
            var programList = new List<string>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line.Trim() == string.Empty)
                {
                    break;
                }

                programList.Add(line);
            }

            var program = new ExpressionParser(string.Join("\n", programList));
            program.Eval();
        }

        public static void RunProgramFromFile(string fileName)
        {
            var programText = File.ReadAllText(fileName);
            var expressionParser = new ExpressionParser(fileName);

            expressionParser.Eval();
        }
    }
}
