namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        private const int DefaultAncientBehemothAttack = 19;
        private const int DefaultAncientBehemothDefense = 19;
        private const int DefaultAncientBehemothHealth = 300;
        private const decimal DefaultAncientBehemothDamage = 40;

        private const int AncientBehemothDefenseReduction = 80;
        private const int AncientBehemothDoubleDefenseRounds = 5;

        public AncientBehemoth()
            : base(DefaultAncientBehemothAttack, DefaultAncientBehemothDefense, DefaultAncientBehemothHealth, DefaultAncientBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(AncientBehemothDefenseReduction));
            this.AddSpecialty(new DoubleDefenseWhenDefending(AncientBehemothDoubleDefenseRounds));
        }
    }
}
