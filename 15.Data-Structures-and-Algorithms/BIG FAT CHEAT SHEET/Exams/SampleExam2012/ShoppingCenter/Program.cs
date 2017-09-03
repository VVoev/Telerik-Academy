using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    public class Program
    {
        public static void Main()
        {
            var center = new ShoppingCenter();
            int n = int.Parse(Console.ReadLine());

            var result = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ').ToList();
                var commandName = line[0];

                line.RemoveAt(0);
                var args = string.Join(" ", line).Split(';');

                if (commandName == "AddProduct")
                {
                    result.AppendLine(center.Add(args[0], decimal.Parse(args[1]), args[2]));
                }
                else if (commandName == "DeleteProducts")
                {
                    if (args.Length == 2)
                    {
                        result.AppendLine(center.DeleteProducts(args[0], args[1]));
                    }
                    else
                    {
                        result.AppendLine(center.DeleteProducts(args[0]));
                    }
                }
                else if (commandName == "FindProductsByName")
                {
                    result.AppendLine(center.FindProductsByName(args[0]));
                }
                else if (commandName == "FindProductsByPriceRange")
                {
                    result.AppendLine(center.FindProductsByPriceRange(decimal.Parse(args[0]), decimal.Parse(args[1])));
                }
                else if (commandName == "FindProductsByProducer")
                {
                    result.AppendLine(center.FindProductsByProducer(args[0]));
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public override string ToString()
        {
            return "{" + string.Format("{0};{1};{2:f2}", this.Name, this.Producer, this.Price) + "}";
        }

        public string GetPairValue()
        {
            return this.Name + ":" + this.Producer;
        }

        public int CompareTo(Product other)
        {
            int resultOfCompare = Name.CompareTo(other.Name);
            if (resultOfCompare == 0)
            {
                resultOfCompare = Producer.CompareTo(other.Producer);
            }
            if (resultOfCompare == 0)
            {
                resultOfCompare = Price.CompareTo(other.Price);
            }
            return resultOfCompare;
        }
    }

    public class ShoppingCenter
    {
        private MultiDictionary<string, Product> names;
        private MultiDictionary<string, Product> producers;
        private MultiDictionary<string, Product> namesAndProducers;
        private OrderedMultiDictionary<decimal, Product> prices;

        public ShoppingCenter()
        {
            this.names = new MultiDictionary<string, Product>(true);
            this.producers = new MultiDictionary<string, Product>(true);
            this.namesAndProducers = new MultiDictionary<string, Product>(true);
            this.prices = new OrderedMultiDictionary<decimal, Product>(true);
        }

        public string Add(string name, decimal price, string producer)
        {
            var newProduct = new Product(name, price, producer);

            this.names.Add(newProduct.Name, newProduct);
            this.prices.Add(newProduct.Price, newProduct);
            this.producers.Add(newProduct.Producer, newProduct);
            this.namesAndProducers.Add(newProduct.GetPairValue(), newProduct);

            return "Product added";
        }

        public string DeleteProducts(string name, string producer)
        {
            var key = new Product(name, 0.0m, producer).GetPairValue();
            if (!this.namesAndProducers.ContainsKey(key))
            {
                return "No products found";
            }

            foreach (var product in this.namesAndProducers[key])
            {
                this.names.Remove(product.Name, product);
                this.prices.Remove(product.Price, product);
                this.producers.Remove(product.Producer, product);
            }

            int removedCount = this.namesAndProducers[key].Count;
            this.namesAndProducers.Remove(key);

            return removedCount + " products deleted";
        }

        public string DeleteProducts(string producer)
        {
            if (!this.producers.ContainsKey(producer))
            {
                return "No products found";
            }

            foreach (var product in this.producers[producer])
            {
                this.namesAndProducers.Remove(new Product(product.Name, 0.0m, product.Producer).GetPairValue(), product);
                this.names.Remove(product.Name, product);
                this.prices.Remove(product.Price, product);
            }

            var removedCount = this.producers[producer].Count;
            this.producers.Remove(producer);

            return removedCount + " products deleted";
        }

        public string FindProductsByName(string name)
        {
            if (!this.names.ContainsKey(name))
            {
                return "No products found";
            }

            return this.FormatProductsPrint(this.names[name]);
        }

        public string FindProductsByPriceRange(decimal from, decimal to)
        {
            var targetProducts = this.prices.Range(from, true, to, true);
            if (targetProducts.Values.Count == 0)
            {
                return "No products found";
            }

            return this.FormatProductsPrint(targetProducts.Values);
        }

        public string FindProductsByProducer(string producer)
        {
            if (!this.producers.ContainsKey(producer))
            {
                return "No products found";
            }

            return this.FormatProductsPrint(this.producers[producer]);
        }

        public string FormatProductsPrint(ICollection<Product> products)
        {
            var copy = new List<Product>(products);
            copy.Sort();

            var result = new StringBuilder();
            foreach (var product in copy)
            {
                result.AppendLine(product.ToString());
            }

            return result.ToString().Trim();
        }
    }
}