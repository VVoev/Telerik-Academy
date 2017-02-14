using NUnit.Framework;
using System;

namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    [TestFixture]
    public class GetResources_Should
    {
        [Test]
        [TestCase("create resources gold(20) silver(30) bronze(40))")]
        [TestCase("create resources gold(20) bronze(40) silver(30))")]
        [TestCase("create resources silver(30) bronze(40) gold(20))")]
        [TestCase("create resources silver(30) gold(20) bronze(40))")]
        [TestCase("create resources bronze(40) gold(20) silver(30))")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void ShouldReturnCorrectValues_WhenValidParametersAreUsed(string command)
        {
            //Arrange
            var factory = new ResourcesFactory();
            var goldCoins = 20;
            var silverCoinns = 30;
            var bronzeCoins = 40;

            //Act
            var resources = factory.GetResources(command);


            //Assert
            Assert.AreEqual(resources.GoldCoins, goldCoins);
            Assert.AreEqual(resources.SilverCoins, silverCoinns);
            Assert.AreEqual(resources.BronzeCoins, bronzeCoins);
        }

        [Test]
        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void InvalidOperationException_WhenCommandIsInvalid(string command)
        {
            //Arrange
            var factory = new ResourcesFactory();

            //Act && Assert
            var expectedMsg = "Invalid command";
            var exception = Assert.Throws<InvalidOperationException>(() => factory.GetResources(command));
            var actualMsg = exception.Message;

            //Assert
            StringAssert.Contains(expectedMsg, actualMsg);
        }

        [Test]
        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void ShouldThrowOverFlowException_WhenCommandIsValidButNumberIsLargerThanIntMaxValue(string command)
        {
            //Arrange
            var factory = new ResourcesFactory();

            //Act && Arrange
            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}
