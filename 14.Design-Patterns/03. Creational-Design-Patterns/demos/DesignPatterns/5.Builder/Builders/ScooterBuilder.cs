using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Builder.Builders
{
    class ScooterBuilder : VehichleBuilder
    {
        public ScooterBuilder()
        {
            this.Vehichkle = new Vehichle("Scooter");

        }
        public override void BuildFrame()
        {
            this.Vehichkle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            this.Vehichkle["engine"] = "125 cc";
        }

        public override void BuildWheels()
        {
            this.Vehichkle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            this.Vehichkle["doors"] = "No Doors";
        }
    }
}
