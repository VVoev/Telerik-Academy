using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class CommandsInstallCommandExecute_Should
    {
        [Test]
        public void PerformOperationFromTheInstallerShouldReturnCorrectOperation()
        {
            //Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
            installerMock.Setup(x => x.Operation).Returns(Enums.InstallerOperation.Install);
            var install = installerMock.Object;
            var package = packageMock.Object;
            //Act
            var command = new InstallCommandExtended(install, package);
            var operation = command.Installer.Operation;

            //Assert
            Assert.AreSame(Enums.InstallerOperation.Install.ToString(), operation.ToString());

        }
    }
}
