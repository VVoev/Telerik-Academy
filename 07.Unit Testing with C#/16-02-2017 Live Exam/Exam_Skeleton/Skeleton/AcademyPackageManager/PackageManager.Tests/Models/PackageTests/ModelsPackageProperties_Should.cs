using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class ModelsPackageProperties_Should
    {
        [TestCase("short name")]
        [TestCase("very very very very very very very very very very very very very very very very very very very very log name")]
        public void NameShouldBeSetCorreclt_WhenValidNamesIsPassed(string name)
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var version = versionMock.Object;
            var package = new Package(name, version);

            //Act && Assert
            Assert.AreEqual(name, package.Name);
        }
        [TestCase(null)]
        public void NameShouldThrowException_WhenNullValueIsPassed(string value)
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var version = versionMock.Object;
            string name = value;

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Package(name, version));
        }

        [Test]
        public void VersionShouldBeSetCorreclt_WhenValidVersionIsPassed()
        {
            //Arrange
            string name = "some name";
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(5);
            var version = versionMock.Object;
            var package = new Package(name, version);

            //Act && Assert
            Assert.AreEqual(5, package.Version.Major);
        }

        [Test]
        public void VersionShouldThrowArgumentNullException_WhenNullVersionIsPassed()
        {
            //Arrange
            string name = "some name";

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Package(name, null));
        }

        [Test]
        public void UrlShouldBeSetCorreclt_WhenValidDataIsPassed()
        {
            //Arrange
            string name = "some name";
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(1);
            versionMock.Setup(x => x.Minor).Returns(1);
            versionMock.Setup(x => x.Patch).Returns(1);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);
            var version = versionMock.Object;
            var package = new Package(name, version);

            //Act
            string url = "1.1.1-alpha";

            //Assert
            Assert.AreEqual(url, package.Url);
            StringAssert.Contains("alpha", package.Url.ToString());
        }
    }
}
