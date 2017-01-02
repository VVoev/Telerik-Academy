namespace ArmyOfCreatures.Extended.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Logic.Creatures;
    using Specialties;

    public class WolfRaider : Creature
    {
        public WolfRaider() 
            : base(8, 5, 10, 3.5m)
        {
            AddSpecialty(new DoubleDamage(7));
        }
    }
}
