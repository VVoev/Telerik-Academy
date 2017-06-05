using _4.AbstractFactory.Factories;
using _4.AbstractFactory.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AbstractFactory
{
    public class OnlinePizzaDomino 
    {
        private readonly AbstractPizzaFactory factory;

        public OnlinePizzaDomino(AbstractPizzaFactory factory)
        {
            this.factory = factory;
        }

        public CheesePizza DeliverCheesePizza()
        {
            return this.factory.MakeCheesePizza();
        }

        public QuatroFormadji DeliverQuatroPizza()
        {
            return this.factory.MakeQuatroFormadjiPizza();
        }

        public PeperonniPizza DeliverPeperonniPizza()
        {
            return this.factory.MakePeperonniPizza();
        }
    }
}
