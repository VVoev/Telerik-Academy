using System;
using System.Collections;
using System.Collections.Generic;

namespace _4.AbstractFactory.Pizzas
{
    public class PeperonniPizza : Pizza
    {
        private readonly string madeBy;

        public PeperonniPizza(IEnumerable<string> ingredients,string madeBy)
            :base(ingredients)
        {
            this.madeBy = madeBy;
        }

        public override string Name
        {
            get
            {
                return string.Format($@"Peperonni piza made by {this.madeBy}");
            }
        }
    }
}
