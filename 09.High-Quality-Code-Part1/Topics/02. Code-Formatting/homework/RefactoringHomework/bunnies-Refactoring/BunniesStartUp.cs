namespace High.Quality.Code.BadExample
{
    using System.Collections.Generic;
    using System.IO;

    using Bunnies_Refactoring.Common;
    using Bunnies_Refactoring.Enums;
    using Bunnies_Refactoring.Models;

    public class BunniesStartUp
    {
        public static void Main(string[] args)
        {
            var bunnies = new List<Bunny>
            {
                new Bunny
                {
                    Name = "Leonid",
                    Age = 1,
                    FurType = FurType.NotFluffy
                },
                new Bunny
                {
                    Age = 2,
                    Name = "Rasputin",
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    FurType = FurType.ALittleFluffy,
                    Name = "Tiberii",
                    Age = 3,
                },
                new Bunny
                {
                    Name = "Neron",
                    FurType = FurType.ALittleFluffy,
                    Age = 1
                },
                new Bunny
                {
                    Name = "Klavdii",
                    Age = 3,
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Name = "Vespasian",
                    Age = 3,
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Name = "Domician",
                    Age = 4,
                    FurType = FurType.FluffyToTheLimit
                },
                new Bunny
                {
                    Name = "Tit",
                    Age = 2,
                    FurType = FurType.FluffyToTheLimit
                }
            };
        }

        public void IntroduceBunnies(IList<Bunny> bunnies)
        {
            var consoleWriter = new ConsoleWriter();
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }
        }

        public void CreateBunniesFromFile()
        {
            var bunniesFilePath = @"..\..\bunnies.txt";
            var fileStream = File.Create(bunniesFilePath);
            fileStream.Close();
        }

        public void SavesBunniesToFile(IList<Bunny> bunnies, string bunniesFilePath)
        {
            using (var streamWriter = new StreamWriter(bunniesFilePath))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }
    }
}