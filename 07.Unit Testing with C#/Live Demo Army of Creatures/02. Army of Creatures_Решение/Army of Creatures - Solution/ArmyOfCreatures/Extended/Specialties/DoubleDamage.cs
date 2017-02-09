namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;
    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleDamage : Specialty
    {
        private const int MinRounds = 1;
        private const int MaxRounds = 10;

        private int rounds;

        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds
        {
            get
            {
                return this.rounds;
            }

            set
            {
                if (value < MinRounds || value > MaxRounds)
                {
                    string errorMessage = string.Format(
                        "The number of rounds should be in the range {0} - {1} inclusive.",
                        MinRounds,
                        MaxRounds);

                    throw new ArgumentOutOfRangeException("rounds", errorMessage);
                }

                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.Rounds <= 0)
            {
                return currentDamage;
            }

            this.rounds--;
            return currentDamage * 2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Rounds);
        }
    }
}
