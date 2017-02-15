using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.NewTests.Models.CourseTests
{
    [TestFixture]
    public  class StartingDate_Should
    {
        public const string name = "George";
        public const int lecturesPerWeek = 5;
        public readonly DateTime start = new DateTime(2010, 5, 5);
        public readonly DateTime end = new DateTime(2010, 6, 6);

        [Test]
        public void StartingDateShouldThrowArgumentNullException_WhenPassedValueIsInvalid()
        {
            //Arrange
            var course = new Course(name, lecturesPerWeek, start, end);
            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => course.StartingDate = null);
        }
        [Test]
        public void StartingDateShouldNotThrowArgumentNullException_WhenPassedValueIsValid()
        {
            //Arrange
            var course = new Course(name, lecturesPerWeek, start, end);
            //Act 
            var newDate = new DateTime(2012, 5, 5);
            course.StartingDate = newDate;
            //Assert
            Assert.AreEqual(newDate, course.StartingDate);
        }
        [Test]
        public void StartingDateShouldCorreclyAssingPassedValue_WhenPassedValueIsValid()
        {
            //Arrange
            var course = new Course(name, lecturesPerWeek, start, end);
            //Act && Assert
            Assert.AreEqual(course.StartingDate, start);
        }


    }
}
