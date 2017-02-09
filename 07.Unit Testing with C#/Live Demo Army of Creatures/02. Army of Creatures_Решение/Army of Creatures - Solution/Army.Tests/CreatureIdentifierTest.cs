using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using NUnit.Framework;
using System;

namespace Army.Tests
{
    [TestFixture]
    public class CreatureIdentifierTest
    {
        [Test]
        [Category("CreatureIdentifier")]
        [TestCase(null)]
        public void CreatureIdentifier_WhenNullValueIsPassed_ShouldThrowArgumentNullException(string param)
        { 
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(param));
        }
        [Category("CreatureIdentifier")]
        [TestCase("Angel(test)")]
        public void CreatureIdentifier_WhenInvalidValueIsPassed_ShouldThrowArgumentNullException(string param)
        {
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString(param));
        }

        [Category("CreatureIdentifier")]
        [TestCase("Angel")]
        public void CreatureIdentifier_WhenInvalidValueIsPassed_ShouldThrowIndexOutOfRangeWhenParamIsWithoutBracket(string param)
        {
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString(param));
        }

        [Category("CreatureIdentifier")]
        [TestCase("Angel(2)")]
        [TestCase("Devil(44)")]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturnCreature(string param)
        {
            var identfitier = CreatureIdentifier.CreatureIdentifierFromString(param);

            Assert.IsInstanceOf<CreatureIdentifier>(identfitier);
        }

        [Category("CreatureIdentifier")]
        [TestCase("Angel(2)",2)]
        [TestCase("Devil(44)",44)]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturnCorrectCreatureNumber(string param,int number)
        {
            var identfitier = CreatureIdentifier.CreatureIdentifierFromString(param);
            Assert.AreEqual(identfitier.ArmyNumber, number);
        }

        [Category("CreatureIdentifier")]
        [TestCase("Angel(2)", 2)]
        [TestCase("Devil(44)", 44)]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturnCorrectCreature(string param, int number)
        {
            var identfitier = CreatureIdentifier.CreatureIdentifierFromString(param);

            var getCreature = param.Split('(');
            var expected = getCreature[0];

            Assert.AreEqual(identfitier.CreatureType, expected);
        }

        [Category("CreatureIdentifier")]
        [Test]
        [TestCase("Angel(2)")]
        [TestCase("Devil(44)")]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturnExpectedString(string param)
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString(param);

            Assert.AreEqual(identifier.ToString(), param);
        }
    }
}
