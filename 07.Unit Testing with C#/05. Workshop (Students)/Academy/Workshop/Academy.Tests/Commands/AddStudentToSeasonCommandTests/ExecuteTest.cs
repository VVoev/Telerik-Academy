using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Academy.Tests.Commands.AddStudentToSeasonCommandTests.Mock;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Academy.Tests.Commands.AddStudentToSeasonCommandTests
{
    [TestFixture]
    public class ExecuteTest
    {

        [Test]
        [Category("ExecuteTest")]
        public void ThrowException_WhenStudentIsAlreadyInTheSeason()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();

            studentMock.Setup(x => x.Username).Returns("Pesho");
            engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });
            seasonMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);
            Assert.Throws<ArgumentException>(() => command.Execute(new List<string>() { "Pesho", "0" }));
        }

        [Category("ExecuteTest")]
        [Test]
        public void WillAddStudentSuccesfully_WhenStudentIsNotPartOfTheSeason()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();
            var studentMockNotPesho = new Mock<IStudent>();

            studentMock.Setup(x => x.Username).Returns("Pesho");
            engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMockNotPesho.Object });
            engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });
            var studentInSeason = new List<IStudent>() { studentMockNotPesho.Object };
            studentMock.Setup(x => x.Username).Returns("Not Pesho");
            seasonMock.Setup(x => x.Students).Returns(studentInSeason);
            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            //Act
            var result = command.Execute(new List<string>() { "Pesho", "0" });

            //Assert
            Assert.AreEqual(2, seasonMock.Object.Students.Count);


        }
    }
}
