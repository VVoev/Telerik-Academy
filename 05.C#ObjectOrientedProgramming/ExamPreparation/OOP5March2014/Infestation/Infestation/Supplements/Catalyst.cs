namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Catalyst : ISupplement
    {
        public Catalyst(int healthEffect, int powerEffect, int aggressionEffect)
        {
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
            this.AggressionEffect = aggressionEffect;
        }
        public virtual int AggressionEffect { get; protected set; }

        public virtual int HealthEffect { get; protected set; }
        
        public virtual int PowerEffect { get; protected set; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {

        }
    }
}
