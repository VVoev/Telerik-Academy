using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Builder.Builders
{
    public class CarBuilder : VehichleBuilder
    {
        public CarBuilder()
        {
            this.Vehichkle = new Vehichle("Car");
        }
        public override void BuildDoors()
        {
            this.Vehichkle["doors"] = "Two doors";
        }

        public override void BuildEngine()
        {
            this.Vehichkle["engine"] = "2500cc";
        }

        public override void BuildFrame()
        {
            this.Vehichkle["frame"] = "Carbon Frame";
        }

        public override void BuildWheels()
        {
            this.Vehichkle["wheels"] = "Four Wheels";

        }
    }
}
