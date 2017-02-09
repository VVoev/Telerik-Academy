namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    public class WolfRaider : Creature
    {
        private const int DefaultWolfRaiderAttack = 8;
        private const int DefaultWolfRaiderDefense = 5;
        private const int DefaultWolfRaiderHealth = 10;
        private const decimal DefaultWolfRaiderDamage = 3.5M;

        private const int WolfRaiderDoubleDamageRounds = 7;

        public WolfRaider()
            : base(DefaultWolfRaiderAttack, DefaultWolfRaiderDefense, DefaultWolfRaiderHealth, DefaultWolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(WolfRaiderDoubleDamageRounds));
        }
    }
}
