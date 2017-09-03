using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _06.Phones
{
    public class Startup
    {
        public static void Main()
        {
            string phoneBookPath = @"..\..\phone-book.txt";
            var peopleDict = ReadPhoneBook(phoneBookPath);
            string commandsPath = @"..\..\commands.txt";

            ReadCommands(commandsPath, peopleDict);
        }

        public static Dictionary<string, HashSet<string>> ReadPhoneBook(string filePath)
        {
            var peopleDict = new Dictionary<string, HashSet<string>>();

            using (var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    var currentPersonInfo = line.Split('|').Select(x => x.Trim()).ToArray();

                    string personName = currentPersonInfo[0];
                    string personTown = currentPersonInfo[1];
                    string personPhone = currentPersonInfo[2];

                    if (!peopleDict.ContainsKey(personName))
                    {
                        peopleDict.Add(personName, new HashSet<string>());
                    }

                    peopleDict[personName].Add(personTown);
                    peopleDict[personName].Add(personPhone);
                    line = reader.ReadLine();
                }
            }

            return peopleDict;
        }

        public static void ReadCommands(string commandsPath, Dictionary<string, HashSet<string>> peopleDict)
        {
            using (var reader = new StreamReader(commandsPath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var commandArgs = line.Split(' ').ToList();
                    ProcessCommand(commandArgs, peopleDict);

                    line = reader.ReadLine();
                }
            }
        }

        private static void ProcessCommand(List<string> commandArgs, Dictionary<string, HashSet<string>> peopleDict)
        {
            string personName = commandArgs[1];


            bool isMatch = peopleDict.ContainsKey(personName);

            if (commandArgs.Count == 3)
            {
                string townName = commandArgs[2];
                isMatch = isMatch && peopleDict[personName].Contains(townName);
            }

            if (isMatch)
            {
                Console.WriteLine($"{personName} => {string.Join(", ", peopleDict[personName])}");
            }
        }
    }
}
