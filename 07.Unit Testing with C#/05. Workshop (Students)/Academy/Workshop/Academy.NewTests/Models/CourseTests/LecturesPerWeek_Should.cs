using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.NewTests.Models.CourseTests
{
    [TestFixture]
    public class LecturesPerWeek_Should
    {
        public const string name = "George";
        public const int lecturesPerWeek = 5;
        public readonly DateTime start = new DateTime(2010, 5, 5);
        public readonly DateTime end = new DateTime(2010, 6, 6);

        [Test]
        [TestCase(0)]
        [TestCase(8)]
        public void LecturesPerWeekShouldThrowArgumentException_WhenPassedValueIsInValid(int value)
        {
            //Arrange
            var course = new Course(name, lecturesPerWeek, start, end);
            //Act && Assert
            Assert.Throws<ArgumentException>(() => course.LecturesPerWeek = value);
        }
        [Test]
        [TestCase(2)]
        [TestCase(6)]
        public void LecturesPerWeekShouldNotThrowArgumentException_WhenPassedValueIsValid(int value)
        {
            //Arrange
            var course = new Course(name, lecturesPerWeek, start, end);
            //Act
            course.LecturesPerWeek = value;
            //Assert
            Assert.AreEqual(value, course.LecturesPerWeek);
        }
        [Test]
        [TestCase(2)]
        [TestCase(6)]
        public void LecturesPerWeekShouldCorrectlyAssigPassedValue_WhenPassedValueIsValid(int value)
        {
            //Arrange
            var course = new Course(name, value, start, end);
            //Act && Assert
            Assert.AreEqual(value, course.LecturesPerWeek);
        }

    }
}
