using NUnit.Framework;
using System;
using Tasker.Models;

namespace Tasker.Tests.Models.TaskTests
{
    [TestFixture]
    public class DescriptionTest
    {
        [Test]
        [Category("Description")]
        [TestCase("")]
        [TestCase("      ")]
        [TestCase(null)]
        public void DesriptionShouldThrowError_WhenPassedNullOrEmptyValueOrWhiteSpaces(string value)
        {
            //Arange
            var sut = new Task();

            //Act && Assert
            Assert.Throws<ArgumentException>(() => sut.Description = value);
        }

        [Test]
        [Category("Description")]
        [TestCase("S")]
        [TestCase("hsjjakshjajwlqkjwlq")]
        [TestCase("_|_")]
        public void DescriptionShoulNotThrowError_WhenPassedValidString(string value)
        {
            var sut = new Task();
            Assert.DoesNotThrow(() => sut.Description = value);
        }
        [Test]
        [Category("Description")]
        [TestCase("S")]
        [TestCase("hsjjakshjajwlqkjwlq")]
        [TestCase("_|_")]
        public void DescritionShouldSetValue_WhenPassedValidValue(string value)
        {
            //Arrange
            var sut = new Task();
            //Act
            sut.Description = value;
            //Assert
            Assert.AreEqual(sut.Description, value);
        }
    }
}
