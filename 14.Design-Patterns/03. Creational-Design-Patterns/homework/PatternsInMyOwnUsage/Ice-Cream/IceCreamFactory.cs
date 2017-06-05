using System;
using System.Collections.Generic;

namespace Ice_Cream
{
    public  class IceCreamFactory
    {
        public IceCream GetIceCream(Types type)
        {
            switch (type)
            {
                case Types.Chocolate:
                    return new IceCream(new List<string> { "Banana", "Chocolate" }, 2, Toppings.Chocolate);
                case Types.Caramel:
                    return new IceCream(new List<string> { "Vanila", "Lemon" }, 2, Toppings.Caramel);
                case Types.Banana:
                    return new IceCream(new List<string> { "Banana", "PineApple" }, 2, Toppings.Strawberry);
                case Types.Vanilla:
                    return new IceCream(new List<string> { "Pingui", "Almonds" }, 2, Toppings.PassionFruit);
                default: throw new ArgumentException("Invalid");
            }
        }
    }
}
