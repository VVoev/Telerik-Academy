using Academy.Models;
using NUnit.Framework;
using Academy.Models.Enums;
using Moq;
using Academy.Models.Contracts;

namespace Academy.NewTests.Models.SeasonTests
{
    [TestFixture]
    public  class ListUsers_Should
    {
        public const int starting = 2016;
        public const int ending = 2017;
        public readonly Initiative academy = Initiative.SoftwareAcademy;

        [Test]
        public void ListUserShouldReturnListOfStudentsAndTrainers_WhenCollectionIsnotEmptry()
        {
            //Arrange
            var season = new Season(starting, ending, academy);
            var studentMock = new Mock<IStudent>();
            studentMock.Setup(x => x.ToString());
            season.Students.Add(studentMock.Object);

            //Act
            var test = season.ListUsers();

            //Assert
            studentMock.Verify(x => x.ToString(), Times.Exactly(1));
        }

        [Test]
        public void ListUserShouldReturnListOfStudentsAndTrainers_WhenCollectionIsEmpty()
        {
            //Arrange
            var season = new Season(starting, ending, academy);
            //Act
            var test = season.ListUsers();
            //Assert
            StringAssert.Contains("no users",test);
        }
    }
}
