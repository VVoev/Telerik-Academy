using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4.AbstractFactory.Pizzas;

namespace _4.AbstractFactory.Factories
{
    public class VictoriaPizza : AbstractPizzaFactory
    {
        private const string name = "Victoria Pizza Loven Park";

        public override CheesePizza MakeCheesePizza()
        {
            var ingredients = new List<string> { "Tomato", "Cheese", "Mozarella" };
            var pizza = new CheesePizza(ingredients, name);
            return pizza;
        }

        public override PeperonniPizza MakePeperonniPizza()
        {
            var ingredients = new List<string> { "Tomato", "Cheese", "Mozarella","Peperonni","Olives" };
            var pizza = new PeperonniPizza(ingredients, name);
            return pizza;
        }

        public override QuatroFormadji MakeQuatroFormadjiPizza()
        {
            var ingredients = new List<string> { "Tomato", "BlueCheese", "Mozarella", "YellowCheese", "Feta" };
            var pizza = new QuatroFormadji(ingredients, name);
            return pizza;
        }
    }
}
