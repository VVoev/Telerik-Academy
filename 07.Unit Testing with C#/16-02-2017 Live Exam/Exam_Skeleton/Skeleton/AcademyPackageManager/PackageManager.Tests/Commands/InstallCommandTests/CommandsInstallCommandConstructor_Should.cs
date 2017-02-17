using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class CommandsInstallCommandConstructor_Should
    {
        [Test]
        public void BugFoundHere()
        {
            //Arrange

            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
            var install = installerMock.Object;
            var package = packageMock.Object;
            //Act
            var command = new InstallCommandExtended(installerMock.Object, packageMock.Object);

            //Assert
            Assert.AreEqual(install, command.Installer);
        }

        [Test]
        public void SetingRightValuesShouldInitializeObject_WhenDataIsValid()
        {
            //Arrange

            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
            var install = installerMock.Object;
            var package = packageMock.Object;
            //Act
            var command = new InstallCommandExtended(installerMock.Object, packageMock.Object);

            //Assert
            Assert.AreEqual(package, command.Package);
        }
    }
}
