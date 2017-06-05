using System.Collections.Generic;
using System.Text;

namespace _4.AbstractFactory.Pizzas
{
    public abstract class Pizza
    {
        private readonly IList<string> ingredients;

        protected Pizza(IEnumerable<string> Ingredients)
        {
            this.ingredients = new List<string>(Ingredients);
        }

        public abstract string Name { get; }

        public IEnumerable<string> Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.AppendLine(string.Join(" ", this.ingredients));
            return sb.ToString();
        }

    }
}
