using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OnlineMarket
{
    public class Program
    {
        public static void Main()
        {
            var market = new OnlineMarket();
            var result = new StringBuilder();

            while (true)
            {
                var line = Console.ReadLine().Split(' ');
                if (line[0] == "end")
                {
                    return;
                }

                if (line[0] == "add")
                {
                    Console.WriteLine(market.Add(line[1], double.Parse(line[2]), line[3]));
                }
                else if (line[0] == "filter")
                {
                    if (line[2] == "type")
                    {
                        Console.WriteLine(market.FilterByType(line[3]));
                    }
                    else if (line.Length == 7)
                    {
                        Console.WriteLine(market.FilterByPriceFromTo(double.Parse(line[4]), double.Parse(line[6])));
                    }
                    else if (line[3] == "from")
                    {
                        Console.WriteLine(market.FilterByPriceFromTo(double.Parse(line[4]), double.MaxValue));
                    }
                    else
                    {
                        Console.WriteLine(market.FilterByPriceFromTo(double.MinValue, double.Parse(line[4])));
                    }
                }
            }
        }
    }

    public class OnlineMarket
    {
        private HashSet<string> usedNames;
        private Dictionary<string, SortedSet<Product>> types;
        private Dictionary<double, SortedSet<Product>> prices;
        private SortedSet<double> allPrices;

        public OnlineMarket()
        {
            this.usedNames = new HashSet<string>();
            this.types = new Dictionary<string, SortedSet<Product>>();
            this.prices = new Dictionary<double, SortedSet<Product>>();
            this.allPrices = new SortedSet<double>();
        }

        public string Add(string name, double price, string type)
        {
            if (this.usedNames.Contains(name))
            {
                return string.Format("Error: Product {0} already exists", name);
            }

            if (!this.prices.ContainsKey(price))
            {
                this.prices[price] = new SortedSet<Product>();
            }

            if (!this.types.ContainsKey(type))
            {
                this.types[type] = new SortedSet<Product>();
            }

            var product = new Product(name, price, type);

            this.allPrices.Add(price);
            this.types[type].Add(product);
            this.prices[price].Add(product);
            this.usedNames.Add(name);

            return string.Format("Ok: Product {0} added successfully", name);
        }

        public string FilterByType(string type)
        {
            if (!this.types.ContainsKey(type))
            {
                return string.Format("Error: Type {0} does not exists", type);
            }

            return string.Format("Ok: {0}", string.Join(", ", this.types[type].Take(10)));
        }

        public string FilterByPriceFromTo(double from, double to)
        {
            var ranges = this.allPrices.GetViewBetween(from, to);

            var result = new SortedSet<Product>();

            int index = 0;

            foreach (var price in ranges)
            {
                foreach (var currentPrice in this.prices[price])
                {
                    if (index == 10)
                    {
                        return string.Format("Ok: {0}", string.Join(", ", result));
                    }

                    result.Add(currentPrice);
                    index++;
                }
            }

            return string.Format("Ok: {0}", string.Join(", ", result));
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(Product other)
        {
            var comparer = this.Price.CompareTo(other.Price);

            if (comparer != 0)
            {
                return comparer;
            }

            comparer = this.Name.CompareTo(other.Name);

            if (comparer != 0)
            {
                return comparer;
            }

            return this.Type.CompareTo(other.Type);
        }

        public override string ToString()
        {
            return string.Format("{0}({1:})", this.Name, this.Price);
        }
    }
}

