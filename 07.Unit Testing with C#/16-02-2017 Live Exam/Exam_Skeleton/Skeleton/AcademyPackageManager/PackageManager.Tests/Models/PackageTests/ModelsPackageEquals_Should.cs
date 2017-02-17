using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class ModelsPackageEquals_Should
    {
        [Test]
        public void EqualsShouldthrowArgumentNullException_WhenSecondPackageIsNull()
        {
            //Arrange
            string name = "somename";
            var versionMock = new Mock<IVersion>();
            string otherName = "othername";
            var otherVersionMock = new Mock<IVersion>();

            var version = versionMock.Object;
            var otherVersion = otherVersionMock.Object;


            //Act
            var firstPackage = new Package(name, version);
            var secondPackage = new Package(otherName, otherVersion);

            //Assert
            var msg = Assert.Throws<ArgumentNullException>(() => firstPackage.Equals(null));
            var message = msg.Message;
            StringAssert.Contains("Value cannot be null", message);
        }

        [Test]
        public void IsPassedObjectIPackage_WhenIPackageIsUsed()
        {
            //Arrange
            string name = "somename";
            var versionMock = new Mock<IVersion>();
            string otherName = "othername";
            var otherVersionMock = new Mock<IVersion>();

            var version = versionMock.Object;
            var otherVersion = otherVersionMock.Object;


            //Act
            var firstPackage = new Package(name, version);
            var secondPackage = new Package(otherName, otherVersion);

            //Assert
            Assert.IsInstanceOf<IPackage>(firstPackage);
            Assert.IsInstanceOf<IPackage>(secondPackage);
        }

        [Test]
        public void FirstPackageShouldBeEqualToSecondPAckage_WhenTheyAreUsingSameNamee()
        {
            //Arrange
            string name = "somename";
            var versionMock = new Mock<IVersion>();
            var dependacyMock = new Mock<ICollection<IPackage>>();
            //string otherName = "othername";
            var otherVersionMock = new Mock<IVersion>();
            //var otherDependacyMock = new Mock<ICollection<IPackage>>();

            var version = versionMock.Object;
            var dependacy = dependacyMock.Object;
            var otherVersion = otherVersionMock.Object;
            //var otherDependacy = otherDependacyMock.Object;


            //Act
            var firstPackage = new Package(name, version);
            var secondPackage = new Package(name, otherVersion);

            //Assert
            Assert.IsTrue(firstPackage.Equals(secondPackage));
        }

        [Test]
        public void FirstPackageShouldNotBeEqualToSecondPAckage_WhenTheyAreUsingDifferentNamee()
        {
            //Arrange
            string name = "somename";
            var versionMock = new Mock<IVersion>();
            var dependacyMock = new Mock<ICollection<IPackage>>();
            string otherName = "othername";
            var otherVersionMock = new Mock<IVersion>();
            //var otherDependacyMock = new Mock<ICollection<IPackage>>();

            var version = versionMock.Object;
            var dependacy = dependacyMock.Object;
            var otherVersion = otherVersionMock.Object;
            //var otherDependacy = otherDependacyMock.Object;


            //Act
            var firstPackage = new Package(name, version);
            var secondPackage = new Package(otherName, otherVersion);

            //Assert
            Assert.IsFalse(firstPackage.Equals(secondPackage));
            Assert.AreNotEqual(firstPackage, secondPackage);
        }
    }
}
