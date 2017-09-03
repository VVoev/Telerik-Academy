using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _01.PlayerRanking
{
    public class Program
    {
        static void Main()
        {
            Run();
        }

        public static void Run()
        {
            var ranklist = new RankList();
            string line = null;
            while (true)
            {
                line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                var commandArgs = line.Split(' ');
                string commandName = commandArgs[0];

                if (commandName == "add")
                {
                    var player = new Player()
                    {
                        Name = commandArgs[1],
                        Type = commandArgs[2],
                        Age = int.Parse(commandArgs[3]),
                        Position = int.Parse(commandArgs[4]),
                    };

                    ranklist.Add(player);
                }
                else if (commandName == "find")
                {
                    var playerType = commandArgs[1];
                    ranklist.Find(playerType);
                }
                else if (commandName == "ranklist")
                {
                    int start = int.Parse(commandArgs[1]);
                    int end = int.Parse(commandArgs[2]);

                    ranklist.ListRank(start, end);
                }
            }

            ranklist.Print();
        }
    }

    public class RankList
    {
        private BigList<Player> playersList;
        private Dictionary<string, OrderedBag<Player>> playerTypes;
        private StringBuilder output;

        public RankList()
        {
            this.playersList = new BigList<Player>();
            this.playerTypes = new Dictionary<string, OrderedBag<Player>>();
            this.output = new StringBuilder();
        }

        public void Add(Player player)
        {
            int index = player.Position - 1;
            if (!this.playerTypes.ContainsKey(player.Type))
            {
                this.playerTypes[player.Type] = new OrderedBag<Player>();
            }

            this.playerTypes[player.Type].Add(player);
            this.playersList.Insert(index, player);

            this.output.AppendLine(string.Format("Added player {0} to position {1}", player.Name, player.Position));
        }

        public void Find(string playerType)
        {
            if (!this.playerTypes.ContainsKey(playerType))
            {
                this.playerTypes[playerType] = new OrderedBag<Player>();
            }

            var targetTypes = this.playerTypes[playerType];

            this.output.Append(string.Format("Type {0}: ", playerType));
            int index = 0;
            foreach (var pl in targetTypes)
            {
                if (index >= 5 || index >= targetTypes.Count)
                {
                    break;
                }

                output.Append(pl.ToString());

                if (index != 4 && index != targetTypes.Count - 1)
                {
                    output.Append("; ");
                }

                index++;
            }

            this.output.AppendLine();
        }

        public void ListRank(int start, int end)
        {
            start--;
            end--;

            var range = this.playersList.Range(start, end - start + 1);

            int index = 0;
            foreach (var pl in range)
            {
                output.Append(string.Format("{0}. {1}", ++start, pl.ToString()));

                if (index != range.Count - 1)
                {
                    output.Append("; ");
                }

                index++;
            }

            this.output.AppendLine();
        }

        public void Print()
        {
            Console.WriteLine(this.output.ToString().Trim());
        }
    }

    public class Player : IComparable
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public int Position { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Player;
            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            var other = obj as Player;
            if (this.Name == other.Name)
            {
                return other.Age - this.Age;
            }

            return this.Name.CompareTo(other.Name);
        }
    }
}
