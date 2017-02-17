using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System.Collections.Generic;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class ModelsPackageConstructor_Should
    {
        [Test]
        public void DependanciesAreSetCorrectly_WhenTheyAreOptionalMissing()
        {
            //Arrange
            var name = "somename";
            var versionMock = new Mock<IVersion>();
            var version = versionMock.Object;
            var package = new Package(name, version);

            //Act && Assert
            Assert.AreEqual(package.Version, version);
        }
        [Test]
        public void DependanciesAreSetCorrectly_WhenTheyAreOptionalMissingAgain()
        {
            //Arrange
            var name = "somename";
            var versionMock = new Mock<IVersion>();
            var version = versionMock.Object;
            var package = new Package(name, version);

            //Act && Assert
            Assert.IsTrue(package.Dependencies.Count == 0);
        }

        [Test]
        public void DependanciesAreSetCorrectly_WhenTheyArePassedAndNotMissing()
        {
            //Arrange
            var name = "somename";
            var versionMock = new Mock<IVersion>();
            var dependacyMock = new Mock<ICollection<IPackage>>();
            var version = versionMock.Object;
            var dependacy = dependacyMock.Object;

            //Act
            var package = new Package(name, version,dependacy);

            //Assert
            Assert.AreSame(dependacy, package.Dependencies);
            //Assert.AreEqual(dependacy, package.Dependencies);
            //Assert.IsTrue(dependacy == package.Dependencies);
        }
    }
}
