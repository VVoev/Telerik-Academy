using _5.Builder.Builders;
using _5.Builder.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // We can choose concrete constructor (director)
            IVehicleConstructor constructor = new VehicleConstructor();

            // And we can choose concrete builder
            VehichleBuilder builder = new CarBuilder();
            constructor.Construct(builder);

            VehichleBuilder miniBuilder = new ScooterBuilder();
            constructor.Construct(miniBuilder);

            builder.Vehichkle.Show();
            miniBuilder.Vehichkle.Show();

        }
    }
}
