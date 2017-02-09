using ArmyOfCreatures.Extended;
using ArmyOfCreatures.Logic;
using NUnit.Framework;
using System;

namespace Army.Tests
{
    [TestFixture]
    public class CreaturesFactoryTest
    {
        [Test]
        [Category("Creatures Factory")]
        [TestCase("Angel")]
        [TestCase("Archangel")]
        [TestCase("ArchDevil")]
        [TestCase("Behemoth")]
        [TestCase("Devil")]
        public void CreatureMakingSuccesfully_WhenProvidedValidCreature(string creature)
        {
            var factory = new ExtendedCreaturesFactory();
            var expectedCreature = factory.CreateCreature(creature);

            Assert.AreEqual(expectedCreature.GetType().Name, creature);
        }

        [Test]
        [Category("Creatures Factory")]
        [TestCase("Zebra")]
        [TestCase("Rabbit")]
        [TestCase("Cat")]
        public void CreatureFactoryThrowingError_WhenProvidedInvalidCreature(string creature)
        {
            var factory = new ExtendedCreaturesFactory();

            try
            {
                var expectedCreature = factory.CreateCreature(creature);
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual($"Invalid creature type \"{creature}\"!", ex.Message);
            }
           
        }

    }
}
