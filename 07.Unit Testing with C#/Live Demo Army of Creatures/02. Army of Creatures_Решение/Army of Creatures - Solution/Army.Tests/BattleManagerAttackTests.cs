using Army.Tests.MockedClasses;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using Moq;
using NUnit.Framework;
using System;

namespace Army.Tests
{
    [TestFixture]
    public class BattleManagerAttackTests
    {
        [Test]
        [Category("BattleManagerAttackTests")]
        public void Attack_WhenAttackCreatureIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(13)");

            Assert.Throws<ArgumentException>(() => battleManager.Attack(identifier, identifier));   
        }
        [Test]
        [Category("BattleManagerAttackTests")]
        public void Attack_WhenDeffendCreatureIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(13)");

            Assert.Throws<ArgumentException>(() => battleManager.Attack(identifier, identifier));
        }

        [Test]
        [Category("BattleManagerAttackTests")]
        public void Attack_WhenAttackIsSuccesfull_ShouldCallWriteLine4Times()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(3)");

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<String>()));

            battleManager.Attack(identifier, identifier);

            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }

    }
}
