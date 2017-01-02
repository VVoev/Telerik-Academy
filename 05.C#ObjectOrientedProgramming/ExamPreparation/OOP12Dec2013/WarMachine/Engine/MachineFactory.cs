namespace WarMachine.Engine
{
    using Interfaces;
    using Models;

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            var pilot = new Pilot(name);
            return pilot;
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            IFighter fighter = new Fighter(name, attackPoints, defensePoints, stealthMode);
            return fighter;
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = new Tank(name, attackPoints, defensePoints);
            return tank;
        }
    }
}
