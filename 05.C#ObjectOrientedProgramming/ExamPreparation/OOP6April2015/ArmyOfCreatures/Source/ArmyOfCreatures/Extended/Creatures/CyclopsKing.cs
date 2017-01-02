namespace ArmyOfCreatures.Extended.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Logic.Creatures;
    using Specialties;

    public class CyclopsKing : Creature
    {
        public CyclopsKing() 
            : base(17, 13, 70, 18m)
        {
            AddSpecialty(new AddAttackWhenSkip(3));
            AddSpecialty(new DoubleAttackWhenAttacking(4));
            AddSpecialty(new DoubleDamage(1));
        }
    }
}
