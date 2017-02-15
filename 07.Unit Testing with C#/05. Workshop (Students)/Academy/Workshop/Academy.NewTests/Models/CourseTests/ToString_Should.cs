using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.NewTests.Models.CourseTests
{
    [TestFixture]
     public class ToString_Should
    {
        public const string name = "George";
        public const int lecturesPerWeek = 5;
        public readonly DateTime start = new DateTime(2010, 5, 5);
        public readonly DateTime end = new DateTime(2010, 6, 6);

        [Test]
        public void ToStringShouldReturnPassedDataAListOfLectures_WhenCollectionIsEmpty()
        {
            //Arrange
            var course = new Course(name, lecturesPerWeek, start, end);
            //Act
            course.ToString();
            //Assert
            StringAssert.Contains("no lectures", course.ToString());
        }

        [Test]
        public void ToStringShouldReturnPassedDataAListOfLectures_WhenCollectionIsNotEmpty()
        {
            //Arrange
            var course = new Course(name, lecturesPerWeek, start, end);

            var lecture = new Mock<ILecture>();
            lecture.Setup(x => x.ToString());
            course.Lectures.Add(lecture.Object);

            //Act
            course.ToString();

            //Assert
            lecture.Verify(x => x.ToString(), Times.Once);
        }
    }
}
