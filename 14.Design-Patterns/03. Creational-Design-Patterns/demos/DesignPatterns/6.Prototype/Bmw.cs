using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Prototype
{
    public class Bmw : BmwPrototype
    {

        public Bmw(int engine, int tyres, int weight)
        {
            this.Engine = engine;
            this.Tyres = tyres;
            this.Weight = weight;
        }
        public int Engine { get; set; }

        public int Tyres { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return string.Format($@"Engine {this.Engine} with tyres {this.Tyres} and weight {this.Weight}");
        }

        public override Bmw Clone()
        {
            // Options of cloning in .NET (http://stackoverflow.com/a/966534/1862812)
            // Clone Manually - Tedious, but high level of control
            // Clone with MemberwiseClone - Fastest but only creates a shallow copy, i.e. for reference-type fields the original object and it's clone refer to the same object.
            // Clone with Reflection - Shallow copy by default, can be re-written to do deep copy. Advantage: automated. Disadvantage: reflection is slow.
            // Clone with Serialization - Easy, automated. Give up some control and serialization is slowest of all.
            return this.MemberwiseClone() as Bmw;
        }



    }
}
