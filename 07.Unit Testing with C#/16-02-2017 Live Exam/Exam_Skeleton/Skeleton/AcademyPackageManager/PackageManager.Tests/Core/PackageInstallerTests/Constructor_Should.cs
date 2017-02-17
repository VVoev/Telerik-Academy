using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using System.Collections.Generic;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void RestoringPackages_WhenObjectIsConstructedAtLeastOnce()
        { 
            //Arrange 
            var downloadMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var download = downloadMock.Object;
            var project = projectMock.Object;

            //Act
            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>() { });
            var packageInstaller = new PackageInstaller(download, project);
            
            //Assert
            projectMock.Verify(x => x.PackageRepository, Times.Once);

        }
    }
}
