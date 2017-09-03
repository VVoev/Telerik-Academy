using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace UnitsOfWork
{
    public class Program
    {
        public static void Main()
        {
            var engine = new Engine();

            var result = new StringBuilder();
            while (true)
            {
                var line = Console.ReadLine().Split();

                if (line[0][0] == 'e')
                {
                    break;
                }

                if (line[0][0] == 'a')
                {
                    var unit = new Unit(line[1], line[2], int.Parse(line[3]));
                    result.AppendLine(engine.Add(unit));
                }
                else if (line[0][0] == 'r')
                {
                    result.AppendLine(engine.Remove(line[1]));
                }
                else if (line[0][0] == 'f')
                {
                    result.AppendLine(engine.Find(line[1]));
                }
                else if (line[0][0] == 'p')
                {
                    result.AppendLine(engine.Power(int.Parse(line[1])));
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

    public class Engine
    {
        private Dictionary<string, Unit> units;
        private SortedSet<Unit> sortedUnits;

        public Engine()
        {
            this.units = new Dictionary<string, Unit>();
            this.sortedUnits = new SortedSet<Unit>();
        }

        public string Add(Unit unit)
        {
            if (this.units.ContainsKey(unit.Name))
            {
                return string.Format("FAIL: {0} already exists!", unit.Name);
            }

            this.units[unit.Name] = unit;
            this.sortedUnits.Add(unit);

            return string.Format("SUCCESS: {0} added!", unit.Name);
        }

        public string Remove(string unitName)
        {
            var newUnit = new Unit(unitName);
            if (!this.units.ContainsKey(unitName))
            {
                return string.Format("FAIL: {0} could not be found!", unitName);
            }

            this.sortedUnits.Remove(this.units[unitName]);
            this.units.Remove(unitName);

            return string.Format("SUCCESS: {0} removed!", unitName);
        }

        public string Find(string unitType)
        {
            var builder = new StringBuilder();
            builder.Append("RESULT: ");

            var result = this.sortedUnits.Where(x => x.Type == unitType)
                    .Take(10);

            builder.AppendLine(string.Join(", ", result));

            return builder.ToString().Trim();
        }


        public string Power(int count)
        {
            var builder = new StringBuilder();

            var result = sortedUnits.Take(count);
            builder.Append("RESULT: ");
            builder.AppendLine(string.Join(", ", result));

            return builder.ToString().Trim();
        }
    }


    public class Unit : IComparable<Unit>
    {
        public Unit(string name)
        {
            this.Name = name;
        }

        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public int CompareTo(Unit other)
        {
            if (this.Attack == other.Attack)
            {
                return this.Name.CompareTo(other.Name);
            }

            return other.Attack.CompareTo(this.Attack);
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Unit;
            return this.Name == other.Name;
        }
    }
}
