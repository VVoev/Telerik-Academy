using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.FactoryMethod.Product;

namespace _3.FactoryMethod.Manufacturer
{
    class Samsung : Manufacturer
    {
        public override GSM ManufactureGSM()
        {
            var phone =  new Galaxy { Width = 6, Height = 4 };
            return phone;
        }
    }
}
