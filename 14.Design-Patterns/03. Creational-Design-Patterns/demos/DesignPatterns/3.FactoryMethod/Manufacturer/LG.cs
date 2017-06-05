using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.FactoryMethod.Product;

namespace _3.FactoryMethod.Manufacturer
{
    class LG : Manufacturer
    {
        public override GSM ManufactureGSM()
        {
            var phone = new G5 { BatteryLife = 3000, Width = 6 };
            return phone;
        }
    }
}
