namespace Infestation.Supplements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Weapon : EffectableSupplement
    {
        private const int powerEffect = 10;
        private const int aggressionEffect = 3;

        public Weapon() : base(0,Weapon.powerEffect,Weapon.aggressionEffect)
        {
            this.hasEffect = false;
        }
        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.hasEffect = true;
            }
        }
    }
}
