using NUnit.Framework;
using PackageManager.Models;
using System;

namespace PackageManager.Tests.Models.ProjectsTests
{
    [TestFixture]
    public class ModelsProjectProperties_Should
    {
        [TestCase("short name")]
        [TestCase("Very very very very very very very very very very very very very very very very very very very very  log name ")]
        public void NameShouldBeSetCorreclt_WhenNameIsCorrect(string value)
        {
            //Arrange
            string name = value;
            string location = "Sofia";
            //Act
            var project = new Project(name, location);
            //Assert
            Assert.AreEqual(name, project.Name);
        }

        [TestCase(null)]
        public void NameShouldThrowArgumentException_WhenNameIsNull(string value)
        {
            //Arrange
            string name = value;
            string location = "Sofia";

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Project(name, location));
        }

        [TestCase("Lom")]
        [TestCase("London london donLondon london donLondon london donLondon london donLondon london donLondon london donLondon")]
        public void LocationShouldBeSetCorreclt_WhenLocationIsCorrect(string value)
        {
            //Arrange
            string name = "Project Alfa";
            string location = value;

            //Act
            var project = new Project(name, location);
            //Assert
            Assert.AreEqual(location, project.Location);
        }

        [TestCase(null)]
        public void LocationShouldThrowArgumentException_WhenLocationIsNull(string value)
        {
            //Arrange
            string name = "Project Alfa";
            string location = value;

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Project(name, location));
        }
    }
}
