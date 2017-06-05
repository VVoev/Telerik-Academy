using System.Collections.Generic;

namespace Ice_Cream
{
    public class IceCream
    {
        private const double price = 1.49;

        public IEnumerable<string> Flavours { get; set; }

        public int Balls { get; set; }

        public Toppings Toppings { get; set; }

        Types Types { get; set; }

        public IceCream(IEnumerable<string> flavours, int balls, Toppings toppings)
        {
            this.Flavours = new List<string>(flavours);
            this.Balls = balls;
            this.Toppings = toppings;
            this.Types = (Types)toppings;

        }

        public double GetBillInGrams()
        {
            return this.Balls * price;
        }

        public override string ToString()
        {
            return $@"{this.GetType().Name} with flavours {string.Join(" ", this.Flavours)} toppings {this.Toppings} total of {this.Balls}";
        }

        
    }
}
