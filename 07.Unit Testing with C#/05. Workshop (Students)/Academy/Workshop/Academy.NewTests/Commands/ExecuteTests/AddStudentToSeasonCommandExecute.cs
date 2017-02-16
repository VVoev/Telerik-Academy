using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Academy.NewTests.Commands.Execute
{
    [TestFixture]
    public class AddStudentToSeasonCommandExecute
    {
        [Test]
        public void ShouldThrowArgumentExceptionWhenThePassedStudentIsAlreadyPartOfTheSeason()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();


            
            studentMock.Setup(x => x.Username).Returns("Pesho");
            seasonMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            
            //Act
            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            //Assert
            var msg = Assert.Throws<ArgumentException>(() => command.Execute(new List<string>() { "Pesho", "0" }));
            StringAssert.Contains("is already a part of Season", msg.Message);
        }

        [Test]
        public void ShouldCorrectlyAddTheStudentIntoTheSeason_WhenStudentIsNotPartOfTheSeason()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();
            var secondStudentMock = new Mock<IStudent>();

            secondStudentMock.Setup(x => x.Username).Returns("Petar");
            studentMock.Setup(x => x.Username).Returns("Pencho");
            engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });
            seasonMock.Setup(x => x.Students).Returns(new List<IStudent>() {secondStudentMock.Object});

            //Act
            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);
            var msg = command.Execute(new List<string>() { "Pencho", "0" });


            //Assert
            Assert.AreEqual(2, seasonMock.Object.Students.Count);
            StringAssert.Contains("was added to Season", msg.ToString());
        }
        //Should correctly add the found student into the season.
    }
}
