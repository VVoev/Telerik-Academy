using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.NewTests.Models.CourseTests
{
    [TestFixture]
    public class Name_Should
    {
        public const string name = "George";
        public const int lecturesPerWeek = 5;
        public readonly DateTime start = new DateTime(2010, 5, 5);
        public readonly DateTime end = new DateTime(2010, 6, 6);

        [Test]
        [TestCase("I")]
        [TestCase("Very very very very very very very very very very very very very very very very very very very very very long")]
        public void NameShouldThrowArgumentException_WhenPassedValueIsInvalid(string newname)
        {
            //Arrange && Act
            var course = new Course(name, lecturesPerWeek, start, end);
            //Assert
            Assert.Throws<ArgumentException>(() => course.Name = newname);
        }

        [Test]
        public void NameShouldNotThrowArgumentException_WhenPassedValueIsValid()
        {
            //Arrange
            var course = new Course(name, lecturesPerWeek, start, end);
            //Act
            string newname = "Mihaela";
            course.Name = newname;
            //Assert
            Assert.AreEqual(newname, course.Name);
        }

        [Test]
        public void NameShouldCorrectlyAssignPassedValue_WhenPassedValueIsValid()
        {
            //Arrange
            var course = new Course(name, lecturesPerWeek, start, end);
            //Act && Assert
            Assert.AreEqual(name, course.Name);
        }


    }
}
