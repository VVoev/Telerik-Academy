using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _KnackSack_Fitness
{
    class Program
    {
        static void Main(string[] args)
        {

            int TotalProtein = int.Parse(Console.ReadLine());
            int numberOfProducts = int.Parse(Console.ReadLine());
            List<Item> items = new List<Item>();

            for (int i = 0; i < numberOfProducts; i++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();
                var name = line[0];
                var weight = int.Parse(line[1]);
                var price = int.Parse(line[2]);
                var item = new Item(i, weight, price, name);
                items.Add(item);
            }

            int BagCapacity = 5;

            KnapSackProblem problem = new KnapSackProblem();

            int totalValueOfItems = 0;
            List<Item> itemsToBePacked = problem.FindItemsToPack(items, TotalProtein, out totalValueOfItems);

            var suma = itemsToBePacked.Sum((x => x.Price));
            Console.WriteLine(suma);
            foreach (var item in itemsToBePacked)
            {
                Console.WriteLine(item.Name);
            }
        }



        class KnapSackProblem
        {

            public List<Item> FindItemsToPack(List<Item> items, int capacity, out int totalValue)
            {

                int[,] price = new int[items.Count + 1, capacity + 1];
                bool[,] keep = new bool[items.Count + 1, capacity + 1];

                for (int i = 1; i <= items.Count; i++)
                {
                    Item currentItem = items[i - 1];
                    for (int space = 1; space <= capacity; space++)
                    {
                        if (space >= currentItem.Weight)
                        {
                            int remainingSpace = space - currentItem.Weight;
                            int remainingSpaceValue = 0;
                            if (remainingSpace > 0)
                            {
                                remainingSpaceValue = price[i - 1, remainingSpace];
                            }
                            int currentItemTotalValue = currentItem.Price + remainingSpaceValue;
                            if (currentItemTotalValue > price[i - 1, space])
                            {
                                keep[i, space] = true;
                                price[i, space] = currentItemTotalValue;
                            }
                            else
                            {
                                keep[i, space] = false;
                                price[i, space] = price[i - 1, space];
                            }
                        }
                    }
                }

                List<Item> itemsToBePacked = new List<Item>();

                int remainSpace = capacity;
                int item = items.Count;
                while (item > 0)
                {
                    bool toBePacked = keep[item, remainSpace];
                    if (toBePacked)
                    {
                        itemsToBePacked.Add(items[item - 1]);
                        remainSpace = remainSpace - items[item - 1].Weight;
                    }
                    item--;
                }

                totalValue = price[items.Count, capacity];
                return itemsToBePacked;
            }

        }



        public class Item
        {
            public string Name { get; set; }
            public int ID;
            public int Weight;
            public int Price;
            public Item(int id, int weight, int value,string name)
            {
                this.ID = id;
                this.Weight = weight;
                this.Price = value;
                this.Name = name;
            }
            public override string ToString()
            {
                return "ID=" + ID + ",W=" + Weight + ",V=" + Price;
            }
        }


    }
}
