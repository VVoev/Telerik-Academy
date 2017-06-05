using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AbstractFactory.Pizzas
{
    public class QuatroFormadji : Pizza
    {
        private readonly string madeBy;

        public QuatroFormadji(IEnumerable<string> ingredients, string madeBy)
            :base(ingredients)
        {
            this.madeBy = madeBy;
        }

        public override string Name
        {
            get
            {
                return string.Format($@"QuatroFormadji piza made by {this.madeBy}");
            }
        }
    }
}
