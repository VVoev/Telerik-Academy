using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
   public class StartingDateTests
    {
        [Category("StartingDate")]
        [Test]

        public void ReturnTheCorrectValue_WhenCalledWithGetMethod()
        {
            //Arrange && Act
            var course = new Course("some course", 5, new DateTime(2017, 2, 14), new DateTime());

            //Assert
            Assert.AreEqual(new DateTime(2017, 2, 14), course.StartingDate);
        }

        [Category("StartingDate")]
        [Test]

        public void ThrowException_WhenInvalidStartDateIsUsed()
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(2017, 2, 14), new DateTime());

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => course.StartingDate = null);
        }

        [Category("StartingDate")]
        [Test]

        public void SetDesiredNewDate_WhenNewDateIsSet()
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(2017, 2, 14), new DateTime());

            //Act
            course.StartingDate = new DateTime(2011, 5, 5);

            //Assert
            Assert.AreEqual(course.StartingDate, new DateTime(2011, 5, 5));

        }

    }
}
