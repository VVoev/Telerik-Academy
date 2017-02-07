using NUnit.Framework;
using Tasker.Models;

namespace Tasker.Tests.Models.TaskTests
{
    [TestFixture]
    public class CtorTests
    {
        [Test]
        [Category("Constructor")]
        [TestCase("Input")]
        [TestCase("CorrectLongDescription1234567890")]
        public void Ctor_ShouldAssingDescription_WhenInvoked(string value)
        {
            //Arrange && Act
            var expected = value;
            var sut = new Task(expected);
            //Assert
            Assert.AreEqual(expected, sut.Description);


        }
    }
}
