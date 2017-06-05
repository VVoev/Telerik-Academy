using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AbstractFactory.Pizzas
{
    public class CheesePizza : Pizza
    {
        private readonly string madeBy;

        public CheesePizza(IEnumerable<string> ingredients, string madeBy)
            :base(ingredients)
        {
            this.madeBy = madeBy;
        }

        public override string Name
        {
            get
            {
                return string.Format($@"CheesePizza piza made by {this.madeBy}");
            }
        }
    }
}
