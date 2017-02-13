using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class NameTests
    {
        [Category("Name")]
        [Test]
        public void ReturnTheProperWhenGetMethodIsCalled()
        {
            //Arrange
            var course = new Course("some course", 5, new DateTime(), new DateTime());

            //Act
            var result = course.Name;

            //Asert
            Assert.AreEqual(result, "some course");
            
        }
        [Category("Name")]
        [Test]
        [TestCase("I")]
        [TestCase("very long string should throw exception very long string should throw exception very long string should throw exception very long string should throw exception very long string should throw exception very long string should")]
        public void ThrowsArgumentExceptionWhenInvalidValuesArePassed(string name)
        {
            //Arrange && Act
            var course = new Course("some name", 5, new DateTime(), new DateTime());

            //Asert
            Assert.Throws<ArgumentException>(() => course.Name = name);

        }
    }
}
