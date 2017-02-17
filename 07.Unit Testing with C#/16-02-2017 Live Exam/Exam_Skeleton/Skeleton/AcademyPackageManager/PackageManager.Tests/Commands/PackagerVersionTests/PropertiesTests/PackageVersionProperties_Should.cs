using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;

namespace PackageManager.Tests.Commands.PackagerVersionTests.PropertiesTests
{
    [TestFixture]
    public class PackageVersionProperties_Should
    {
        
        [TestCase(-1)]
        [TestCase(-100)]
        public void PackageVersionShouldSetProperertyWithValueMajor_WhenPassedValueIsNotCorrect(int value)
        {
            //Arrange
            int major = value;
            int minor = 1;
            int patch = 2;
            var version = VersionType.alpha;

            //Act && Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, version));
        }
        [TestCase(5)]
        [TestCase(20)]
        public void PackageVersionShouldSetProperertyWithValueMajor_WhenPassedValueIsCorrect(int value)
        {
            //Arrange
            int major = value;
            int minor = 1;
            int patch = 2;
            var version = VersionType.alpha;
            var package = new PackageVersion(major, minor, patch, version);

            //Act && Assert
            Assert.AreEqual(value, package.Major); 
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void PackageVersionShouldSetProperertyWithValueMinor_WhenPassedValueIsNotCorrect(int value)
        {
            //Arrange
            int major = 1;
            int minor = value;
            int patch = 2;
            var version = VersionType.alpha;

            //Act && Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, version));
        }
        [TestCase(5)]
        [TestCase(20)]
        public void PackageVersionShouldSetProperertyWithValueMinor_WhenPassedValueIsCorrect(int value)
        {
            //Arrange
            int major = 1;
            int minor = value;
            int patch = 2;
            var version = VersionType.alpha;
            var package = new PackageVersion(major, minor, patch, version);

            //Act && Assert
            Assert.AreEqual(value, package.Minor);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void PackageVersionShouldSetProperertyWithValuePatch_WhenPassedValueIsNotCorrect(int value)
        {
            //Arrange
            int major = 1;
            int minor = 1;
            int patch = value;
            var version = VersionType.alpha;

            //Act && Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, version));
        }
        [TestCase(5)]
        [TestCase(20)]
        public void PackageVersionShouldSetProperertyWithValuePatch_WhenPassedValueIsCorrect(int value)
        {
            //Arrange
            int major = 1;
            int minor = 2;
            int patch = value;
            var version = VersionType.alpha;
            var package = new PackageVersion(major, minor, patch, version);

            //Act && Assert
            Assert.AreEqual(value, package.Patch);
        }

        [Test]
        public void PackageVersionShouldSetProperertyWithValueVersionType_WhenPassedValueIsNotCorrect()
        {
            //Arrange
            int major = 1;
            int minor = 2;
            int patch = 1;
            var version = VersionType.alpha;
            var package = new PackageVersion(major, minor, patch, version);

            //Act && Assert
            Assert.AreEqual(version, package.VersionType);
        }

        [Test]
        public void PackageVersionShouldSetProperertyWithValueVersionType_WhenPassedValueIsCorrect()
        {
            //Arrange
            int major = 1;
            int minor = 2;
            int patch = 1;
            var version = VersionType.alpha;
            var package = new PackageVersion(major, minor, patch, version);

            //Act && Assert
            Assert.AreEqual(version, package.VersionType);
        }
        [Test]
        public void ConstructorWillSetTheProvidedValues_WhenValuesAreNotCorrectVersionType()
        {
            //Arrange
            int major = 1;
            int minor = 1;
            int patch = 2;
            var version = (VersionType)(-1);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, version));
        }


    }
}
