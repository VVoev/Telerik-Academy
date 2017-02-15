using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Academy.NewTests.Models.CourseTests
{
    [TestFixture]
    public class Constructor_Should
    {
        public const string name = "Petar";
        public const int lecturesPerWeek = 5;
        public readonly DateTime start = new DateTime(2010, 5, 5);
        public readonly DateTime end = DateTime.Parse("2010-6-6");

        [Test]
        public void CorrectlyAssingPasssedName()
        {
            //Arrange
            //Act
            var course = new Course(name, lecturesPerWeek, start, end);
            //Assert
            Assert.AreEqual(name, course.Name);
        }
        [Test]
        public void CorrectlyAssingPasssedLecturesPerWeek()
        {
            //Arrange       
            //Act
            var course = new Course(name, lecturesPerWeek, start, end);
            //Assert
            Assert.AreEqual(lecturesPerWeek, course.LecturesPerWeek);
        }
        [Test]
        public void CorrectlyAssingPasssedStartDate()
        {
            //Arrange
            //Act
            var course = new Course(name, lecturesPerWeek, start, end);
            //Assert
            Assert.AreEqual(start, course.StartingDate);
        }
        [Test]
        public void CorrectlyAssingEndDate()
        {
            //Arrange
            //Act
            var course = new Course(name, lecturesPerWeek, start, end);
            //Assert
            Assert.AreEqual(end, course.EndingDate);
        }

        [Test]
        public void CorrectlyInitializeOnlineStudentsCollection_WhenObjectIsConstructed()
        {
            var course = new Course(name, lecturesPerWeek, start, end);
            Assert.IsTrue(course.OnlineStudents.Count==0);
            Assert.IsNotNull(course.OnlineStudents);
            Assert.IsInstanceOf(typeof(IEnumerable<IStudent>), course.OnlineStudents);
        }

        [Test]
        public void CorrectlyInitializeOnsiteStudentsCollection_WhenObjectIsConstructed()
        {
            var course = new Course(name, lecturesPerWeek, start, end);
            Assert.IsTrue(course.OnsiteStudents.Count == 0);
            Assert.IsNotNull(course.OnsiteStudents);
            Assert.IsInstanceOf(typeof(IEnumerable<IStudent>), course.OnsiteStudents);
        }

        [Test]
        public void CorrectlyInitializeLecturesCollection_WhenObjectIsConstructed()
        {
            var course = new Course(name, lecturesPerWeek, start, end);
            Assert.IsTrue(course.Lectures.Count == 0);
            Assert.IsNotNull(course.Lectures);
            Assert.IsInstanceOf(typeof(IEnumerable<ILecture>), course.Lectures);

        }
    }
}
