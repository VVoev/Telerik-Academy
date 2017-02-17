using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class CommandsInstallCommandFields_Should
    {


        [Test]
        public void ValidaTeFieldsInInstallCommands_WhenUsingRightValuesForPackage()
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
        [Test]
        public void ValidaTeFieldsInInstallCommands_WhenUsingRightValuesForInstall()
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
        public void ValidaTeFieldsInInstallCommandsShouldThrowArgumentNullException_WhenPackageIsNull()
        {
            //Arrange

            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
            var install = installerMock.Object;
            var package = packageMock.Object;


            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommandExtended(installerMock.Object, null));
        }

        [Test]
        public void ValidaTeFieldsInInstallCommandsShouldThrowArgumentNullException_WhenInstallerIsNull()
        {
            //Arrange

            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
            var install = installerMock.Object;
            var package = packageMock.Object;


            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommandExtended(null, package));
        }

        [Test]
        public void ValidaTeFieldsInInstallCommandsShouldThrowArgumentNullException_WhenBothParamsAreNull()
        {
            //Arrange

            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
            var install = installerMock.Object;
            var package = packageMock.Object;


            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommandExtended(null, null));
        }
    }
}
