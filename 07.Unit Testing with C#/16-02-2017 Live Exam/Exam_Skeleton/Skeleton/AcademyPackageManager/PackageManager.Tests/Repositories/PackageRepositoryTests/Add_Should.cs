
using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenPackageIsNull()
        {

            var packageMock = new Mock<ICollection<IPackage>>();
            var loggerMock = new Mock<ILogger>();
            var package = packageMock.Object;
            var logger = loggerMock.Object;

            var somePacket = new Mock<IPackage>();
            somePacket.Setup(x => x.Name).Returns("Penko");

            var packageRepository = new PackageRepository(logger, package);


            Assert.Throws<ArgumentNullException>(() => packageRepository.Add(null));
        }

        [Test]
        public void ShouldAddPackagE_WhenPackageIsNotNull()
        {

            var packageMock = new Mock<ICollection<IPackage>>();

            var loggerMock = new Mock<ILogger>();
            var package = packageMock.Object;
            
            
            var logger = loggerMock.Object;

            var somePacketMock = new Mock<IPackage>();
            somePacketMock.Setup(x => x.Name).Returns("nqkvo value");
            packageMock.Setup(x => x.Add(somePacketMock.Object));
            var somePacket = somePacketMock.Object;


            var packageRepository = new PackageRepository(logger, package);


            
        }
    }
}

