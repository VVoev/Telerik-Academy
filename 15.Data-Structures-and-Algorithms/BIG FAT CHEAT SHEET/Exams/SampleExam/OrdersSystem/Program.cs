using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OrdersSystem
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var orders = new Orders();

            var result = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var command = ProcessCommand(Console.ReadLine());

                if (command.Item1 == "AddOrder")
                {
                    Console.WriteLine((orders.AddOrder(command.Item2[0], double.Parse(command.Item2[1]), command.Item2[2])));
                }
                else if (command.Item1 == "DeleteOrders")
                {
                    Console.WriteLine((orders.DeleteOrders(command.Item2[0])));
                }
                else if (command.Item1 == "FindOrdersByPriceRange")
                {
                    Console.WriteLine((orders.FindOrdersByPriceRange(double.Parse(command.Item2[0]), double.Parse(command.Item2[1]))));
                }
                else if (command.Item1 == "FindOrdersByConsumer")
                {
                    Console.WriteLine((orders.FindOrdersByConsumer(command.Item2[0])));
                }
            }
        }

        public static Tuple<string, string[]> ProcessCommand(string commandAsString)
        {
            int spaceIndex = commandAsString.IndexOf(" ");

            var commandName = commandAsString.Substring(0, spaceIndex);
            var args = commandAsString.Substring(spaceIndex + 1).Split(';');

            return new Tuple<string, string[]>(commandName, args);
        }
    }

    public class Orders
    {
        private MultiDictionary<string, Order> consumers;
        private OrderedMultiDictionary<double, Order> ordersByPrices;
        private SortedSet<double> allPrices;

        public Orders()
        {
            this.consumers = new MultiDictionary<string, Order>(true);
            this.ordersByPrices = new OrderedMultiDictionary<double, Order>(true);
            this.allPrices = new SortedSet<double>();
        }

        public string AddOrder(string name, double price, string consumer)
        {
            var order = new Order() { Name = name, Price = price, Consumer = consumer };
            this.consumers[consumer].Add(order);
            this.ordersByPrices[price].Add(order);
            this.allPrices.Add(price);

            return "Order added";
        }

        public string DeleteOrders(string consumer)
        {
            if (!this.consumers.ContainsKey(consumer))
            {
                return "No orders found";
            }

            foreach (var product in this.consumers[consumer])
            {
                this.ordersByPrices.Remove(product.Price, product);
            }

            var count = this.consumers[consumer].Count;
            this.consumers.Remove(consumer);

            return string.Format("{0} orders deleted", count);
        }

        public string FindOrdersByConsumer(string consumer)
        {
            if (!this.consumers.ContainsKey(consumer))
            {
                return "No orders found";
            }

            var set = new OrderedBag<Order>();
            foreach (var product in this.consumers[consumer])
            {
                set.Add(product);
            }

            return string.Join("\n", set);
        }

        public string FindOrdersByPriceRange(double from, double to)
        {
            var ranges = this.ordersByPrices.Range(from,true, to, true);

            if (ranges.Count == 0)
            {
                return "No orders found";
            }

            var set = new OrderedBag<Order>();
            foreach (var item in ranges)
            {
                foreach (var order in this.ordersByPrices[item.Key])
                {
                    set.Add(order);
                }
            }

            return string.Join("\n", set);
        }
    }

    public class Order : IComparable<Order>
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Consumer { get; set; }

        public int CompareTo(Order other)
        {
            var comparer = this.Name.CompareTo(other.Name);

            return comparer;
        }

        public override string ToString()
        {
            return "{" + string.Format("{0};{1};{2:f2}", this.Name, this.Consumer, this.Price) + "}";
        }
    }
}
