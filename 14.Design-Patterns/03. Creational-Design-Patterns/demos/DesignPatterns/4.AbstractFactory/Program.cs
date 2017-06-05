using _4.AbstractFactory;
using _4.AbstractFactory.Factories;
using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaPlaceLeo = new LeoPizza();
            var cheesePizza = pizzaPlaceLeo.MakeCheesePizza();

            var domino = new OnlinePizzaDomino(pizzaPlaceLeo);
            var cheese = domino.DeliverCheesePizza();
            Console.WriteLine(cheese);

            var pizzaVictoria = new VictoriaPizza();
            var peperoni = pizzaVictoria.MakePeperonniPizza();

            Console.WriteLine(cheesePizza);
            Console.WriteLine(peperoni);
        }
    }
}
