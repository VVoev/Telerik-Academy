namespace AcademyEcosystem.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Zombie : Animal
    {
        private const int sizeOfZombie = 0;
        private const int meatZombie = 10;

        public Zombie(string name, Point location)
            : base(name, location, sizeOfZombie)
        {

        }

        public override int GetMeatFromKillQuantity()
        {
            return meatZombie;
        }
    }
}
