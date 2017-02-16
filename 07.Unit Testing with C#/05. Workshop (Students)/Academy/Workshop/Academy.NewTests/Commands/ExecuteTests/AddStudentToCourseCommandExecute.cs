using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Academy.NewTests.Commands.ExecuteTests
{
    [TestFixture]
    public class AddStudentToCourseCommandExecute
    {
        [Test]
        public void ShouldThrowException_WhenThePassedFormCourseIsInvalid()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();


            studentMock.Setup(x => x.Username).Returns("Pesho");
            engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            courseMock.Setup(x => x.OnlineStudents).Returns(new List<IStudent>());
            courseMock.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

            seasonMock.Setup(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });
            engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);
            Assert.Throws<ArgumentException>(()=> command.Execute(new List<string>() { "Pesho", "0", "0", "Some form" }));
        }

        [Test]
        public void ShouldSuccesfullyAddStudent_WhenThePassedFormCourseIsValidOnline()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();


            studentMock.Setup(x => x.Username).Returns("Pesho");
            engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            courseMock.Setup(x => x.OnlineStudents).Returns(new List<IStudent>());
            courseMock.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

            seasonMock.Setup(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });
            engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);
             var res = command.Execute(new List<string>() { "Pesho", "0", "0", "online" });
            StringAssert.Contains("was added to Course", res.ToString());
        }

        [Test]
        public void ShouldSuccesfullyAddStudent_WhenThePassedFormCourseIsValidOnsite()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();


            studentMock.Setup(x => x.Username).Returns("Pesho");
            engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            courseMock.Setup(x => x.OnlineStudents).Returns(new List<IStudent>());
            courseMock.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

            seasonMock.Setup(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });
            engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);
            var res = command.Execute(new List<string>() { "Pesho", "0", "0", "onsite" });
            StringAssert.Contains("was added to Course", res.ToString());
        }
    }
}
