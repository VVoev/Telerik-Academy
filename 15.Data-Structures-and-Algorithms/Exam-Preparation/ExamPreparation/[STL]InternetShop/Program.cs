using System;
using System.Collections.Generic;
using System.Linq;

namespace _STL_InternetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            var b = new string[numberOfCommands];
            var shop = new Shop();

            var products = new List<Product>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var indexOfSpace = command[0].IndexOf(' ');
                var cuttedCommand = command[0].Substring(0, indexOfSpace);



                if (cuttedCommand == "AddProduct")
                {
                    var name = command[0].Substring(indexOfSpace + 1);
                    var price = decimal.Parse(command[1]);
                    var producer = command[2];

                    var product = new Product(name, price, producer);
                    products.Add(product);
                    shop.AddProduct(product);

                    Console.WriteLine("Product added");
                }

                if (cuttedCommand == "DeleteProducts")
                {
                    var spaceIndex = command[0].IndexOf(' ');
                    var searchedProducer = command[0].Substring(spaceIndex + 1);
                    var removedProductsCounter = products.Count;

                    products.RemoveAll((x => x.Producer == searchedProducer));
                    removedProductsCounter -= products.Count;
                    Console.WriteLine($"{removedProductsCounter} products deleted");
                }

                if (cuttedCommand == "FindProductsByName")
                {
                    var spaceIndex = command[0].IndexOf(' ');
                    var searchedProduct = command[0].Substring(spaceIndex + 1);
                    bool found = false;
                    foreach (var item in products)
                    {
                        if (item.Name == searchedProduct)
                        {
                            found = true;
                            Console.WriteLine($@"{item.Name};{item.Producer};{item.Price:f2}");
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"No products found");
                    }
                }

                if (cuttedCommand == "FindProductsByPriceRange")
                {
                    var spaceIndex = command[0].IndexOf(' ');
                    var searchedProduct = command[0].Substring(spaceIndex + 1);
                    var minRange = int.Parse(searchedProduct);
                    var maxRange = int.Parse(command[1]);
                    var productsByPriceRange = products.Where((x => x.Price >= minRange && x.Price <= maxRange)).ToList();
                    Console.WriteLine(string.Join(" ",productsByPriceRange));
                
                }

                if (cuttedCommand == "FindProductsByProducer")
                {
                    var spaceIndex = command[0].IndexOf(' ');
                    var searchedProduct = command[0].Substring(spaceIndex + 1);
                    bool found = false;
                    var itemsByProducer = new List<Product>();
                    foreach (var item in products)
                    {

                        if (item.Producer == searchedProduct)
                        {
                            found = true;
                            itemsByProducer.Add(item);
                        }
                    }
                    if (found)
                    {
                        var items = itemsByProducer.OrderBy((x => x.Name)).ToList();
                        Console.Write(string.Join(Environment.NewLine, items));
                    }

                    if (!found)
                    {
                        Console.WriteLine($"No products found");
                    }
                }
            }
        }
    }

    class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }


        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }


        public override string ToString()
        {
            return $@"{{{this.Name};{this.Producer};{this.Price}}}";
        }
    }

    class Shop
    {
        public List<Product> Products { get; set; }

        public Shop()
        {
            this.Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            this.Products.Add(product);
        }
    }
}
