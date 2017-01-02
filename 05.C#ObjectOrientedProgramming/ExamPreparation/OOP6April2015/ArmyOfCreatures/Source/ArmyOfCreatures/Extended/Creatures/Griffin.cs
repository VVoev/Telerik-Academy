namespace ArmyOfCreatures.Extended.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Logic.Creatures;
    using Logic.Specialties;

    public class Griffin : Creature
    {
        public Griffin() 
            : base(8, 8, 25, 4.5m)
        {
            AddSpecialty(new DoubleDefenseWhenDefending(5));
            AddSpecialty(new AddDefenseWhenSkip(3));
            AddSpecialty(new Hate(typeof(WolfRaider)));
        }

    }
}
