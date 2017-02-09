namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    public class CyclopsKing : Creature
    {
        private const int DefaultCyclopsKingAttack = 17;
        private const int DefaultCyclopsKingDefense = 13;
        private const int DefaultCyclopsKingHealth = 70;
        private const decimal DefaultCyclopsKingDamage = 18;

        private const int CyclopsKingAttackAddedWhenSkip = 3;
        private const int CyclopsKingDoubleAttackRounds = 4;
        private const int CyclopsKingDoubleDamageRounds = 1;

        public CyclopsKing()
            : base(DefaultCyclopsKingAttack, DefaultCyclopsKingDefense, DefaultCyclopsKingHealth, DefaultCyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsKingAttackAddedWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKingDoubleAttackRounds));
            this.AddSpecialty(new DoubleDamage(CyclopsKingDoubleDamageRounds));
        }
    }
}
