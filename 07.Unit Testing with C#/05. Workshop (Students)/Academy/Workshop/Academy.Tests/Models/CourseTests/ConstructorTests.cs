using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public  class ConstructorTests
    {
        [Test]
        [Category("ConstructorTest")]
        [TestCase("fiv")]
        [TestCase("fivevfivevfivevfivevfivevfivevfivevfivevfivev")]
        public void SetProperName_WhenProperNameIsUsed(string name)
        {
            //Arrange Act
            var course = new Course(name, 5, new DateTime(), new DateTime());

            //Asert
            Assert.AreEqual(name, course.Name);
        }

        [Test]
        [Category("ConstructorTest")]
        [TestCase(1)]
        [TestCase(7)]
        public void SetProperLecturesPerWeek_WhenCorrectDataIsUsed(int number)
        {
            //Arrange & Act
            var course = new Course("name", number, DateTime.Now, DateTime.Now);

            //Assert
            Assert.AreEqual(number, course.LecturesPerWeek);
        }

        [Test]
        [Category("ConstructorTest")]
        public void SetProperStartData_WhenCorrectStartDataIsPassed()
        {
            //Act && Arange
            var day = new DateTime(2017, 2, 14);
            var course = new Course("name", 5, day , new DateTime());

            //Assert
            Assert.AreEqual(day, course.StartingDate);
        }

        [Test]
        [Category("ConstructorTest")]
        public void SetProperEndData_WhenCorrectStartDataIsPassed()
        {
            //Act && Arange
            var day = new DateTime(2017, 2, 14);
            var course = new Course("name", 5, new DateTime(), day);

            //Assert
            Assert.AreEqual(day, course.EndingDate);
        }

        [Test]
        [Category("ConstructorTest")]
        public void TestCollectionsLectures_WhenCourseIsCreated()
        {
            //Act && Arange
            var course = new Course("name", 5, new DateTime(), new DateTime());

            //Assert
            Assert.AreEqual(0, course.Lectures.Count);
            Assert.IsNotNull(course.Lectures);
            Assert.IsInstanceOf(typeof(List<ILecture>), course.Lectures);
        }

        [Test]
        [Category("ConstructorTest")]
        public void TestCollectionsOnlineStudents_WhenCourseIsCreated()
        {
            //Act && Arange
            var course = new Course("name", 5, new DateTime(), new DateTime());

            //Assert
            Assert.AreEqual(0, course.OnlineStudents.Count);
            Assert.IsNotNull(course.OnlineStudents);
            Assert.IsInstanceOf(typeof(List<IStudent>), course.OnlineStudents);
        }

        [Test]
        [Category("ConstructorTest")]
        public void TestCollectionsOnsiteStudents_WhenCourseIsCreated()
        {
            //Act && Arange
            var course = new Course("name", 5, new DateTime(), new DateTime());

            //Assert
            Assert.AreEqual(0, course.OnsiteStudents.Count);
            Assert.IsNotNull(course.OnsiteStudents);
            Assert.IsInstanceOf(typeof(List<IStudent>), course.OnsiteStudents);
        }



    }
}
