using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class ToStringTests
    {
        [Test]
        [Category("ToString")]
        public void ItterateOverTheCollection_WhenTheCollectionIsNotEmpty()
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(), new DateTime(2017, 2, 14));

            var lectureMock = new Mock<ILecture>();

            lectureMock.Setup(x => x.ToString());

            course.Lectures.Add(lectureMock.Object);

            //Act
            course.ToString();

            //Assert
            lectureMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        [Category("ToString")]
        public void ItterateOverTheCollection_WhenTheCollectionIsNotEmpty_JustMock ()
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(), new DateTime(2017, 2, 14));

            var lectureMock = Telerik.JustMock.Mock.Create<ILecture>();

            Telerik.JustMock.Mock.Arrange(() => lectureMock.ToString());

            course.Lectures.Add(lectureMock);
                                               
            //Act
            course.ToString();

            //Assert
            Telerik.JustMock.Mock.Assert(() => lectureMock.ToString(), Telerik.JustMock.Occurs.Once());
        }
        [Test]
        [Category("ToString")]
        public void ItterateOverTheCollection_WhenTheCollectionIsEmpty()
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(), new DateTime(2017, 2, 14));



            //Act
            var result = course.ToString();

            //Assert
            StringAssert.Contains("no lectures", result);
        }
    }
}
