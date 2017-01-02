namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Logic.Battles;
    using Logic.Specialties;
    using System.Globalization;
    public class DoubleDamage : Specialty
    {
        int roundsWithDoubleDamage;

        public DoubleDamage(int rounds)
        {
            if (rounds <= 0 || rounds > 10)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0 and less or equal to 10.");
            }

            this.roundsWithDoubleDamage = rounds;
        }
        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.roundsWithDoubleDamage <= 0)
            {
                // Effect expires after fixed number of rounds
                return currentDamage;
            }
            this.roundsWithDoubleDamage--;
            return currentDamage * 2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.roundsWithDoubleDamage);
        }
    }
}
