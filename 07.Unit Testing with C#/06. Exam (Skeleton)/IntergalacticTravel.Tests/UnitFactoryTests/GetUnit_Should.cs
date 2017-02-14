using IntergalacticTravel.Exceptions;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.UnitFactoryTests
{
    [TestFixture]
    class GetUnit_Should
    {
        [Test]
        public void ReturnNewProcyon_WhenValidCommandIsPassed()
        {
            //Arrange
            var command = "create unit Procyon Gosho 1";
            var factory = new UnitsFactory();

            //Act
            var unit = factory.GetUnit(command);
            
            //Assert
            Assert.IsInstanceOf<Procyon>(unit);
        }
        [Test]
        public void ReturnNewLuyten_WhenValidCommandIsPassed()
        {
            //Arrange
            var command = "create unit Luyten Pesho 2";
            var factory = new UnitsFactory();

            //Act
            var unit = factory.GetUnit(command);

            //Assert
            Assert.IsInstanceOf<Luyten>(unit);
        }

        [Test]
        public void ReturnNewLacaille_WhenValidCommandIsPassed()
        {
            //Arrange
            var command = "create unit Lacaille Tosho 3";
            var factory = new UnitsFactory();

            //Act
            var unit = factory.GetUnit(command);

            //Assert
            Assert.IsInstanceOf<Lacaille>(unit);
        }

        [Test]
        [TestCase("create unit Wolvering George 4")]
        [TestCase("create unit Lacaille George noId")]
        public void InvalidUnitCreationCommandException_WhenInvalidCommandIsPassed(string command)
        {
            //Arrange
            var factory = new UnitsFactory();

            //Act && Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(command));
        }




    }
}
