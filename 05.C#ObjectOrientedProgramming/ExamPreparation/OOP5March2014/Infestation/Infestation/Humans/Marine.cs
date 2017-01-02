namespace Infestation.Humans
{
    using Supplements;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Marine : Human
    {
        private ICollection<ISupplement> supplements;

        public Marine(string id)
            : base(id)
        {
            this.Supplements = new List<ISupplement>();
            AddSupplement(new WeaponrySkill());
        }

        public ICollection<ISupplement> Supplements
        {
            get
            {
                if (this.supplements == null)
                {
                    this.supplements = new List<ISupplement>();
                    AddSupplement(new WeaponrySkill());
                }
                return this.supplements;
            }

            private set
            {
                this.supplements = value;
            }
        }
       
        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            //This method finds the unit with the highest health and attacks it
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MinValue, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health > optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
