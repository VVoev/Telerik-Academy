using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Models.SeasonTests
{
    [TestFixture]
    public class ListCoursesTests
    {
        [Category("TestCourses")]
        [Test]
        public void IterateOverTheCollection_WhenTheCollectionIsNotEmpty()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var courseMock = new Mock<ICourse>();
            courseMock.Setup(x => x.ToString()).Returns("");

            season.Courses.Add(courseMock.Object);

            //Act
            var test = season.ListCourses();

            //Assert
            courseMock.Verify(x => x.ToString(), Times.Once);

        }
        [Category("TestCourses")]
        [Test]
        public void IterateOverTheCollection_WhenTheCollectionIsEmpty()
        {
            //Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var courseMock = new Mock<ICourse>();
            courseMock.Setup(x => x.ToString()).Returns("");

            //Act
            var test = season.ListCourses();
            //Assert
            StringAssert.Contains("no course", test.ToString());

        }
    }
}
