using _4.AbstractFactory.Pizzas;

namespace _4.AbstractFactory.Factories
{
    public abstract class AbstractPizzaFactory
    {
        public abstract CheesePizza MakeCheesePizza();

        public abstract PeperonniPizza MakePeperonniPizza();

        public abstract QuatroFormadji MakeQuatroFormadjiPizza();
    }
}
