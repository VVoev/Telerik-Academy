using Academy.Models.Abstractions;
using NUnit.Framework;
using System;

namespace Academy.NewTests.Models.Abstractions.UserTests
{
    [TestFixture]
    public class User_Should
    {        
       public const string validName = "George";


        [Test]
        public void ReturnProperUserName_WhenConstructorIsCalled()
        {
            //Arrange
            var user = new UserMock(validName);
            //Act && Assert
            Assert.AreEqual(validName, user.Username);
        }

        //Should throw ArgumentException when passed value is invalid.

        //Should not throw when the passed value is valid.

        //Should correctly assign passed value.

        [TestCase("I")]
        [TestCase("Very very very very very very very very very very very very very long name")]
        public void USerShouldThrowArgumentException_WhenPAssedValueIsInvalid(string name)
        {
            //Arrange
            var user = new UserMock(validName);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => user.Username = name);
        }

        [TestCase("Petar")]
        [TestCase("AbuAlKaxabi")]
        public void UserShouldNotThrowException_WhenPAssedValueIsValid(string name)
        {
            //Arrange
            var user = new UserMock(validName);

            //Act
            user.Username = name;

            //Assert
            Assert.AreEqual(name, user.Username);
        }
        [Test]
        public void UserShouldAssignCorrectly_PassedValue()
        {
            //Arrange
            var user = new UserMock(validName);
            //Act && Assert
            Assert.AreEqual("George", user.Username);
        }

    }
}
