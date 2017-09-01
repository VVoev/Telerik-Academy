using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _STL__BigList_PlayerRanking
{
    public class Player : IComparable<Player>
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public string Type { get; set; }

        public Player(string name, string type, int age, int position)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.Position = position;
        }

       

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
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

    }
    public class Ranking
    {
        private Dictionary<string, SortedSet<Player>> playersByType;
        private readonly BigList<Player> ranklist;

        public Ranking()
        {
            this.playersByType = new Dictionary<string, SortedSet<Player>>();
            this.ranklist = new BigList<Player>();
        }

        public void Add(Player player)
        {
            if (!this.playersByType.ContainsKey(player.Type))
            {
                this.playersByType[player.Type] = new SortedSet<Player>();
            }

            this.playersByType[player.Type].Add(player);
            this.ranklist.Insert(player.Position - 1, player);
        }

        public IEnumerable<Player> FindByType(string type)
        {
            if (this.playersByType.ContainsKey(type) == false)
            {
                return Enumerable.Empty<Player>();
            }
            return this.playersByType[type].Take(5);
        }

        public IEnumerable<Player> FindByRank(int from, int to)
        {
            return this.ranklist.Range(from, to - from + 1);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var ranklist = new Ranking();
            var sb = new StringBuilder();
            var line = Console.ReadLine();

            while (line != "end")
            {
                var commandArguments = line.Split(' ');
                var command = commandArguments[0];

                switch (command)
                {
                    case "add":
                        var name = commandArguments[1];
                        var type = commandArguments[2];
                        var age = int.Parse(commandArguments[3]);
                        var position = int.Parse(commandArguments[4]);
                        var player = new Player(name, type, age, position);
                        ranklist.Add(player);
                        sb.AppendLine(string.Format("Added player {0} to position {1}", player.Name, player.Position));
                        break;
                    case "find":
                        var searchedType = commandArguments[1];
                        var finded = ranklist.FindByType(searchedType);
                        sb.AppendLine(string.Format("Type {0}: {1}", searchedType, string.Join("; ", finded)));
                        break;
                    case "ranklist":
                        var from = int.Parse(commandArguments[1]);
                        var to = int.Parse(commandArguments[2]);
                        var playersRanklist = ranklist.FindByRank(from, to).Select(p => new { Position = ++from, Player = p }).ToList();
                        sb.AppendLine(string.Join("; ", playersRanklist.Select(r => string.Format("{0}. {1}", r.Position, r.Player))));
                        break;
                    default:
                        break;
                }
                line = Console.ReadLine();
            }
            Console.WriteLine(sb.ToString());
        }

    }
}
