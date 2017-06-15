using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Services;
using System;

namespace ProjectManager.Tests.CachingServices
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WillCreateSuccesfully_WhenTimeSpanIsProvided()
        {
            //Arange
            var span = new TimeSpan(3);
            //Act
            var cashS = new CachingService(span);
            //Assert
            Assert.IsNotNull(cashS);
        }

        [Test]
        public void ThrowException_WhenTimeSpanIsLessThanZero()
        {
            //Arange
            var span = TimeSpan.MinValue;
            //Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CachingService(span));
        }

        [Test]
        public void AssertCash()
        {
        }

    }
}
