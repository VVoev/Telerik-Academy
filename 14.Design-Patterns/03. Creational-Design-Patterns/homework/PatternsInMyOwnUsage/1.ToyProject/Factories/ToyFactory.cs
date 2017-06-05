using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyProject.Toys;

namespace _1.ToyProject.Factories
{
    public abstract class ToyFactory
    {
        public abstract ComputerToy MakeTeddyBearWithComputer();

        public abstract SpinToy MakeSuperSpinner();
    }
}
