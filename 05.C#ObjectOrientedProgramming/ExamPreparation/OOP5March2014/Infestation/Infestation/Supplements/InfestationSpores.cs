namespace Infestation.Supplements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class InfestationSpores : EffectableSupplement, ISupplement
    {
        private const int aggressionEffect = 20;
        private const int powerEffect = -1;

        public InfestationSpores() : base(0,InfestationSpores.powerEffect,InfestationSpores.aggressionEffect)
        {
            this.hasEffect = true;
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.hasEffect = false;
            }
        }
    }
}
