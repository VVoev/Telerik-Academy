namespace SchoolSystem.Tests.Models
{
    using NUnit.Framework;
    using SchoolSystemCli.Models;
    using SchoolSystemCli.Models.Enums;
    using System;
    [TestFixture]

    class MarkTests
    {
        [TestCase(2.0f)]
        [TestCase(3.2f)]
        [TestCase(4.1f)]
        [TestCase(5.99f)]
        [TestCase(6)]
        public void MarkShouldWorkWhenNumbersAreCorrect(float mark)
        {
            Assert.DoesNotThrow(() => new Mark(Subject.Bulgarian, mark));
        }

        [TestCase(1.99f)]
        [TestCase(-3.2f)]
        [TestCase(6.01f)]
        public void MarkShouldThrowExceptionWhenPassedValuesAreIncorrect(float mark)
        {
            Assert.Throws<ArgumentException>(() => new Mark(Subject.Bulgarian, mark));
        }
    }
}
