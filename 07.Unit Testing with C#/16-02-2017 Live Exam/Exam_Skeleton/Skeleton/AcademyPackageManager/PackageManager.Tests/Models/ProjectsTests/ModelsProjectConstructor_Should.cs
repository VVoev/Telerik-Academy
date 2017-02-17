using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Models.ProjectsTests
{
    [TestFixture]
     public class ModelsProjectConstructor_Should
    {
        [Test]
        public void PackageRepositoryShouldSetCorrectlyOptionalParameterPackagers_WhenTheyAreProvidedCorrectlyWithOutPackage()
        {
            //Arrange
            string name = "some name";
            string location = "sofia";

            //Act
            var project = new Project(name, location);

            //Assert
            Assert.IsTrue(name == project.Name);
            Assert.IsTrue(location == project.Location);
        }

        [Test]
        public void PackageRepositoryShouldSetCorrectlyOptionalParameterPackagers_WhenTheyAreProvidedCorrectlyWithPackage()
        {
            //Arrange
            string name = "some name";
            string location = "sofia";
            var somePack = new Mock<IRepository<IPackage>>();
            var package = somePack.Object;

            //Act
            var project = new Project(name, location,package);

            //Assert
            Assert.AreEqual(package, project.PackageRepository);

        
        }
    }
}
