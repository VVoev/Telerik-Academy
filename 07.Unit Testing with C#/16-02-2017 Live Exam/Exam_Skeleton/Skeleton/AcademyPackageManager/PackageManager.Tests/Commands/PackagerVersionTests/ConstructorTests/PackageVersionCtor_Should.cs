using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;

namespace PackageManager.Tests.Commands.PackagerVersionTests
{
    [TestFixture]
    public class PackageVersionCtor_Should
    {
        [Test]
        public void ConstructorWillSetTheProvidedValues_WhenValuesAreCorrectMinor()
        {
            //Arrange
            int major = 1;
            int minor = 1;
            int patch = 2;
            var version = VersionType.alpha;
            var package = new PackageVersion(major, minor, patch, version);

            //Act && Assert
            Assert.AreEqual(minor, package.Minor);
        }

        [Test]
        public void ConstructorWillSetTheProvidedValues_WhenValuesAreCorrectMajor()
        {
            //Arrange
            int major = 1;
            int minor = 1;
            int patch = 2;
            var version = VersionType.alpha;
            var package = new PackageVersion(major, minor, patch, version);

            //Act && Assert
            Assert.AreEqual(major, package.Major);
        }

        [Test]
        public void ConstructorWillSetTheProvidedValues_WhenValuesAreCorrectPatch()
        {
            //Arrange
            int major = 1;
            int minor = 1;
            int patch = 2;
            var version = VersionType.alpha;
            var package = new PackageVersion(major, minor, patch, version);

            //Act && Assert
            Assert.AreEqual(patch, package.Patch);
        }

        [Test]
        public void ConstructorWillSetTheProvidedValues_WhenValuesAreCorrectVersionType()
        {
            //Arrange
            int major = 1;
            int minor = 1;
            int patch = 2;
            var version = VersionType.alpha;
            var package = new PackageVersion(major, minor, patch, version);

            //Act && Assert
            Assert.AreEqual(version, package.VersionType);
        }

     

    }
}
