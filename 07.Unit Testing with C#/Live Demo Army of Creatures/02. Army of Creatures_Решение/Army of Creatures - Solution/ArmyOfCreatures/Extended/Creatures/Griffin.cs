namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class Griffin : Creature
    {
        private const int DefaultGriffinAttack = 8;
        private const int DefaultGriffinDefense = 8;
        private const int DefaultGriffinHealth = 25;
        private const decimal DefaultGriffinDamage = 4.5M;

        private const int GriffinDoubleDefenseRounds = 5;
        private const int GriffinAddDefenseWhenSkip = 3;

        public Griffin()
            : base(DefaultGriffinAttack, DefaultGriffinDefense, DefaultGriffinHealth, DefaultGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(GriffinDoubleDefenseRounds));
            this.AddSpecialty(new AddDefenseWhenSkip(GriffinAddDefenseWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
