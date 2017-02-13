using Academy.Tests.Models.Abstractions.UserTests.UserMoczzzz;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.Abstractions.UserTests
{
    [TestFixture]
    public class UsernameTests
    {
        [Test]
        [Category("Abstract Class Test")]
        public void ReturnProperUserName_WhenTheGetMethosIsCalled()
        {
            //Arange
            var user = new UserMock("Pesho");

            //Act
            var foundUSer = user.Username;

            //Assert
            Assert.AreEqual("Pesho", foundUSer);
        }

        [Test]
        [Category("Abstract Class Test")]
        [TestCase("I")]
        [TestCase("very very very very very very very very very very very very very very very very very very very very long")]
        public void WillThrowException_WhenTheGetMethosIsCalled(string name)
        {
            //Arange
            var user = new UserMock("Pesho");

            //Act
            var foundUSer = user.Username;

            //Assert
            Assert.Throws<ArgumentException>(() => user.Username = name);
        }

        [Test]
        [Category("Abstract Class Test")]
        [TestCase("George")]
        public void WillChangeName_WhenCorrectNameIsUSed(string name)
        {
            //Arange
            var user = new UserMock("Pesho");

            //Act
            user.Username = name;

            //Assert
            Assert.AreEqual(name, user.Username);
        }
    }
}
