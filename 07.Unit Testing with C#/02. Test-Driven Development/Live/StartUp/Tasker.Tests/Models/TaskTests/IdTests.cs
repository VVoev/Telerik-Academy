using NUnit.Framework;
using System;
using Tasker.Models;

namespace Tasker.Tests.Models.TaskTests
{
    [TestFixture]
    public class IdTests
    {
        [Test]
        [Category("Task")]
        [TestCase(-1)]
        [TestCase(-10)]
        public void ArgumentShouldThrowArgumentException_WhenPassedValueIsNegative(int value)
        {
            //Arrange 
            var sut = new Task();

            //Act && Assert
            Assert.Throws<ArgumentException>(() => sut.ID = value);
        }

        [Test]
        [Category("Task")]
        [TestCase(1)]
        [TestCase(10)]
        public void ArgumenentShouldNotThrowException_WhenPassedValuesAreValid(int value)
        {
            //Arrange 
            var sut = new Task();
            //Act && Assert
            Assert.DoesNotThrow(() => sut.ID = value);
        }

        [Test]
        [Category("Task")]
        [TestCase(1)]
        [TestCase(10)]
        public void ArgumentShouldSetPassedValue_WhenPassedValueIsValid(int value)
        {
            //Arange
            var sut = new Task();

            //Act
            sut.ID = value;

            //Assert
            Assert.IsTrue(sut.ID == value);
        }




    }
}
