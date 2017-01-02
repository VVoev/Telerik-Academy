using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarMachine.Interfaces
{
    public interface IMachineFactory
    {
        IPilot HirePilot(string name);
        ITank ManufactureTank(string name, double attackPoints, double defensePoints);
        IFighter ManufactureFighter(string name, double attackPoints,
               double defensePoints, bool stealthMode);

    }
}
