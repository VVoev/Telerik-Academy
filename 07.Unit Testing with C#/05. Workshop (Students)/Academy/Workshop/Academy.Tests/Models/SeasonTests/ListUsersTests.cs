using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Models.SeasonTests
{
    [TestFixture]
    public class ListUsersTests
    {
        [Category("TestUsers")]
        [Test]
        public void IterateOverTheCollection_WhenTheCollectionIsNotEmpty()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var studentMock = new Mock<IStudent>();
            studentMock.Setup(x => x.ToString()).Returns("");

            season.Students.Add(studentMock.Object);

            //Act
            var test = season.ListUsers();

            //Assert
            studentMock.Verify(x => x.ToString(), Times.Once);

        }
        [Test]
        [Category("TestUsers")]
        public void IterateOverTheCollection_WhenTheCollectionIsEmpty()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var studentMock = new Mock<IStudent>();
            studentMock.Setup(x => x.ToString()).Returns("");


            //Act
            var test = season.ListUsers();

            //Assert
            StringAssert.Contains("no users", test);

        }
    }
}
