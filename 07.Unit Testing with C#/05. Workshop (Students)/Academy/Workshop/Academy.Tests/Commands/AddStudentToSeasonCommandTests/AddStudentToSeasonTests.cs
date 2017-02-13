using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Tests.Commands.AddStudentToSeasonCommandTests.Mock;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.Tests.Commands.AddStudentToSeasonCommandTests
{
    [TestFixture]
    [Category("Add mocking objects")]
     public class AddStudentToSeasonTests
    {

        [Test]
        public void ThrowArgumentException_WhenThePassedFactoriesAreNull()
        {
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();


            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, engineMock.Object));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedEngineAreNull()
        {
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();


            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryMock.Object, null));
        }

        [Test]
        public void WillSetCorrectFactory_WhenThePassedFactoryIsNotNull()
        {
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            //Act
            var command = new AddStudentToSeasonMock(factoryMock.Object, engineMock.Object);

            //Assert
            Assert.AreSame(factoryMock.Object, command.AcademyFactory);
        }


    }
}
