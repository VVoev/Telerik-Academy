using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class CommandsInstallCommandPropertiesOperation_Should
    {
        [Test]
        public void SetingTheRightValueForTheInstaller_WillReturnRightValueWhenOperationIsPerformed()
        {
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
            installerMock.Setup(x => x.Operation).Returns(Enums.InstallerOperation.Install);
            var install = installerMock.Object;
            var package = packageMock.Object;
            //Act
            var command = new InstallCommandExtended(install, package);

            //Assert
            Assert.IsTrue(command.Installer.Operation == Enums.InstallerOperation.Install);
        }

      
    }
}
