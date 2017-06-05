using System;
using _3.FactoryMethod.Product;

namespace _3.FactoryMethod.Manufacturer
{
    class Apple : Manufacturer
    {
        public override GSM ManufactureGSM()
        {
            var phone = new Iphone7 { BatteryLife = 200, Height = 200, Width = 7, Weight = 6 };
            return phone;
        }
    }
}
