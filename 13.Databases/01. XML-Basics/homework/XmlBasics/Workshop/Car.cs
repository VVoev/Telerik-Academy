using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    class Car
    {
        public Car()
        {

        }
        public int Year { get; set; }

        public int MyProperty { get; set; }

        TransmissionType type { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        Dealer dealer { get; set; }

        public override string ToString()
        {
            return $@"My year is {this.Year}";
        }
    }
}
