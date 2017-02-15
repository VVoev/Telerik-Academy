using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;

namespace Academy.NewTests.Models.SeasonTests
{
    [TestFixture]
     public class ListCourses_Should

    {
        public const int starting = 2016;
        public const int ending = 2017;
        public readonly Initiative academy = Initiative.SoftwareAcademy;

        [Test]
        public void ListCoursesShouldReturnListOfStudentsAndTrainers_WhenCollectionIsnotEmptry()
        {
            //Arrange
            var season = new Season(starting, ending, academy);
            var courseMock = new Mock<ICourse>();
            courseMock.Setup(x => x.ToString());
            season.Courses.Add(courseMock.Object);

            //Act
            var test = season.ListCourses();

            //Assert
            courseMock.Verify(x => x.ToString(), Times.Exactly(1));
        }

        [Test]
        public void ListCoursesShouldReturnListOfStudentsAndTrainers_WhenCollectionIsEmpty()
        {
            //Arrange
            var season = new Season(starting, ending, academy);
            //Act
            var test = season.ListCourses();
            //Assert
            StringAssert.Contains("no courses", test);
        }

    }
}
