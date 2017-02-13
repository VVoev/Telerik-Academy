using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class LecturesPerWeekTest
    {
        [Category("Lectures")]
        [Test]
        
        public void ReturnTheProperWhenGetMethodIsCalled()
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(), new DateTime());
            //Act
            var result = course.LecturesPerWeek;

            //Asert
            Assert.AreEqual(result, 5);
        }

        [Category("Lectures")]
        [Test]
        [TestCase (0)]
        [TestCase (8)]


        public void ShouldThrowExceptionWhenInvalidParametersArePassed(int number)
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(), new DateTime());
            //Act
            var result = number;
            //Asert
            Assert.Throws<ArgumentException>(() => course.LecturesPerWeek = number);
        }
    }
}
