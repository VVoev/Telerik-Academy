using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class EndingDateTests
    {
        [Category("EndingDate")]
        [Test]

        public void ReturnTheCorrectValue_WhenCalledWithGetMethod()
        {
            //Arrange && Act
            var course = new Course("some course", 5, new DateTime(), new DateTime(2017, 2, 14));

            //Assert
            Assert.AreEqual(new DateTime(2017, 2, 14), course.EndingDate);
        }

        [Category("EndingDate")]
        [Test]

        public void ThrowException_WhenInvalidStartDateIsUsed()
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(), new DateTime(2017, 2, 14));

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => course.EndingDate = null);
        }

        [Category("EndingDate")]
        [Test]

        public void SetDesiredNewDate_WhenNewDateIsSet()
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(), new DateTime(2017, 2, 14));

            //Act
            course.EndingDate = new DateTime(2011, 5, 5);

            //Assert
            Assert.AreEqual(course.EndingDate, new DateTime(2011, 5, 5));

        }
    }
}
