using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            Ranklist ranklist = new Ranklist();
            StringBuilder finalResult = new StringBuilder();

            string line = Console.ReadLine();
            while (line != "end")
            {
                Command command = Command.Parse(line);

                switch (command.Name)
                {
                    case "add":
                        Player player = Player.Parse(command.Arguments);
                        ranklist.Add(player);
                        finalResult.AppendLine(string.Format("Added player {0} to position {1}", player.Name, player.Position));

                        break;

                    case "find":
                        string type = command.Arguments[0];
                        IEnumerable<Player> players = ranklist.FindByType(type);
                        finalResult.AppendLine(string.Format("Type {0}: {1}", type, string.Join("; ", players)));

                        break;

                    case "ranklist":
                        int startPosition = int.Parse(command.Arguments[0]) - 1;
                        int endPosition = int.Parse(command.Arguments[1]) - 1;
                        var playersRanklist = ranklist.GetRanklist(startPosition, endPosition).Select(p => new { Position = ++startPosition, Player = p }).ToList();
                        finalResult.AppendLine(string.Join("; ", playersRanklist.Select(r => string.Format("{0}. {1}", r.Position, r.Player))));

                        break;
                    default:
                        throw new InvalidOperationException();
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(finalResult.ToString().Trim());
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; private set; }

        public string Type { get; private set; }

        public int Age { get; private set; }

        public int Position { get; private set; }

        public static Player Parse(IList<string> playerParts)
        {
            return new Player
            {
                Name = playerParts[0],
                Type = playerParts[1],
                Age = int.Parse(playerParts[2]),
                Position = int.Parse(playerParts[3])
            };
        }

        public int CompareTo(Player other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age) * -1;
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }

    public class Command
    {
        public string Name { get; private set; }

        public IList<string> Arguments { get; private set; }

        public static Command Parse(string commandAsString)
        {
            var commandParts = commandAsString.Split(' ');

            var name = commandParts[0];

            var arguments = new List<string>();
            for (int i = 1; i < commandParts.Length; i++)
            {
                arguments.Add(commandParts[i]);
            }

            return new Command
            {
                Name = name,
                Arguments = arguments
            };
        }
    }

    public class Ranklist
    {
        private readonly IDictionary<string, SortedSet<Player>> playerByType;
        private readonly BigList<Player> ranklist;

        public Ranklist()
        {
            this.playerByType = new Dictionary<string, SortedSet<Player>>();
            this.ranklist = new BigList<Player>();
        }

        public void Add(Player player)
        {
            if (!this.playerByType.ContainsKey(player.Type))
            {
                this.playerByType[player.Type] = new SortedSet<Player>();
            }

            this.playerByType[player.Type].Add(player);
            this.ranklist.Insert(player.Position - 1, player);
        }

        public IEnumerable<Player> FindByType(string type)
        {
            if (!this.playerByType.ContainsKey(type))
            {
                return Enumerable.Empty<Player>();
            }

            return this.playerByType[type].Take(5);
        }

        public IEnumerable<Player> GetRanklist(int startPosition, int endPosition)
        {
            return this.ranklist.Range(startPosition, endPosition - startPosition + 1);
        }
    }
}