using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.NewTests.Commands.Adding
{
    [TestFixture]
    public class AddStudentToSeasonCommand_Should
    {
        [Test]
        public void ConstructorShouldThrowArgumentException_WhenPassedProviderEngineIsNull()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryMock.Object, null));
        }
        [Test]
        public void ConstructorShouldThrowArgumentException_WhenPassedProviderFactoryIsNull()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null,engineMock.Object));
        }
        [Test]
        public void ConstructorShouldThrowArgumentException_WhenPassedProvidersAreBothNull()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, null));
        }

        [Test]
        public void ConstructorShouldCorrectlyAssigValues_WhenPassedValuesAreValid()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();


            //Act
            var command = new AddStudentToSeasonCommandMock(factoryMock.Object, engineMock.Object);

            //Asser
            Assert.AreSame(command.Engine, engineMock.Object);
            Assert.AreSame(command.Factory, factoryMock.Object);
        }


    }
}
