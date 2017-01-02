using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    public abstract class EffectableSupplement : Catalyst, ISupplement
    {
        protected bool hasEffect = false;

        protected EffectableSupplement(int healthEffect, int powerEffect, int aggressionEffect) : base(healthEffect, powerEffect, aggressionEffect)
        {

        }
        public override int AggressionEffect
        {
            get
            {
                if (!this.hasEffect)
                {
                    return 0;
                }
                else
                {
                    return base.AggressionEffect;
                }
            }
            protected set { base.AggressionEffect = value; }
        }

        public override int HealthEffect
        {
            get
            {
                if (!this.hasEffect)
                {
                    return 0;
                }
                else
                {
                    return base.HealthEffect;
                }
            }
            protected set { base.HealthEffect = value; }
        }

        public override int PowerEffect
        {
            get
            {
                if (!this.hasEffect)
                {
                    return 0;
                }
                else
                {
                    return base.PowerEffect;
                }
            }
            protected set
            {
                base.PowerEffect = value;
            }
        }
    }
}
