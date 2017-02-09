using Army.Tests.MockedClasses;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;

namespace Army.Tests
{
    [TestFixture]
    public class BattleManagerAddCreaturesTests
    {

        [Test]
        [Category("BattleManagerAddCreaturesTests")]
        public void AddCreatures_WhenCreatureIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(null, 1));           
        }

        [Test]
        [Category("BattleManagerAddCreaturesTests")]
        public void AddCreatures_WhenCreatureIdentifierIsValid_ShouldCreateCreature()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);
           

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            //var fixture = new Fixture();
            //var identifier = fixture.Create<CreatureIdentifier>();

            var creature = new Angel();
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            battleManager.AddCreatures(identifier, 1);

            mockedFactory.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        [Category("BattleManagerAddCreaturesTests")]
        public void AddCreatures_WhenCreatureIdentifierIsValid_WhenLoggedIsCalled()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);


            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            //var fixture = new Fixture();
            //var identifier = fixture.Create<CreatureIdentifier>();

            var creature = new Angel();
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            battleManager.AddCreatures(identifier, 1);

            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.AtLeast(1));
        }
    }
}
