using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class ModelsPackageCompareTo_Should
    {
        [Test]
        public void CompareToShouldthrowArgumentNullException_WhenSecondPackageIsNull()
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
            var msg = Assert.Throws<ArgumentNullException>(() => firstPackage.CompareTo(null));
            var message = msg.Message;
            StringAssert.Contains("object cannot be null", message);
        }

        [Test]
        public void CompareToShouldThrowArgumentException_WhenSecondPackageHaveDifferentName()
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
            Assert.Throws<ArgumentException>(() => firstPackage.CompareTo(secondPackage));
        }
        [Test]
        public void FirstPackageShouldBeHigherThanSecond_WhenFirstVersionIsBigger()
        {
            //Arrange
            string name = "somename";
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Minor).Returns(10);
            var version = versionMock.Object;
            var firstPackage = new Package(name, version);

 
            var otherVersionMock = new Mock<IVersion>();
            var otherVersion = otherVersionMock.Object;
            var secondPackage = new Package(name, otherVersion);


            //Act && Assert
            Assert.AreEqual(1, firstPackage.CompareTo(secondPackage));
        }

        [Test]
        public void FirstPackageWillBeSmallerThanSecond_WhenSecondVersionIsBigger()
        {
            //Arrange
            string name = "somename";
            var versionMock = new Mock<IVersion>();
            var version = versionMock.Object;


            var otherVersionMock = new Mock<IVersion>();
            otherVersionMock.Setup(x => x.Major).Returns(10);
            var otherVersion = otherVersionMock.Object;

            var firstPackage = new Package(name, version);
            var secondPackage = new Package(name, otherVersion);
            //Act && Assert
            Assert.AreEqual(-1, firstPackage.CompareTo(secondPackage));

        }

        [Test]
        public void FirstPackageWillBeEqualToSecond_WhenSecondVersionIsEqualToFirst()
        {
            //Arrange
            string name = "somename";
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(10);
            var version = versionMock.Object;


            var otherVersionMock = new Mock<IVersion>();
            otherVersionMock.Setup(x => x.Major).Returns(10);
            var otherVersion = otherVersionMock.Object;

            var firstPackage = new Package(name, version);
            var secondPackage = new Package(name, otherVersion);
            //Act && Assert
            Assert.AreEqual(0, firstPackage.CompareTo(secondPackage));
        }



        [Test]
        public void PackageShouldBeEqual_WhenVersionIsNotMentioned()
        {
            //Arrange
            string name = "somename";
            var versionMock = new Mock<IVersion>();
            var otherVersionMock = new Mock<IVersion>();

            var version = versionMock.Object;
            var otherVersion = otherVersionMock.Object;


            //Act
            var firstPackage = new Package(name, version);
            var secondPackage = new Package(name, otherVersion);

            //Assert
            Assert.IsTrue(firstPackage.CompareTo(secondPackage) == 0);
        }
    }
}
