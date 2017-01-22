using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Validators;
using Validators.Exceptions;

namespace ValidatorsTests
{
    [TestClass]
    public class UsernameValidatorTests
    {
        private TestContext testContextInstance;

        public TestContext TestContextInstance
        {
            get
            {
                return this.testContextInstance;
            }
            set
            {
                this.testContextInstance = value;
            }
        }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            // You can add common initialization logic here
            // Which is really not a good idea when you write unit tests
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // You can cleanup common resources here
            // If you haven't listen to my previous advice
        }

        /*
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TestContextInstance.WriteLine(TestContextInstance.TestName);
            TestContextInstance.WriteLine(TestContextInstance.TestDeploymentDir);
        }

        [TestCleanup()]
        public void MyTestCleanUp()
        {
            TestContextInstance.WriteLine(TestContextInstance.CurrentTestOutcome.ToString());
        }
        */


        [TestMethod]
        [TestCategory("UsernameValidationTests")]
        public void IsUserNameValid_WillReturnTrue_WhenUserNameDoesNotContainAnyWhiteSpaceOrSpecialChars()
        {
            //Arange
            var usernameValidator = new UsernameValidator();
            var userToBeTested = "PetarPetrov";
            var minSymbols = 5;
            var maxSumbols = 35;
            var expectedResult = true;

            //Act
            var actualResult = usernameValidator.IsUsernameValid(userToBeTested, minSymbols, maxSumbols);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [TestCategory("UsernameValidationTests")]
        [ExpectedException(typeof(InvalidUsernameException),AllowDerivedTypes =true)]
        public void USerNameShouldThrowUserameException_WhenUsernameContainWhiteSpaceChars()
        {
            //Arrange
            var usernameValidator = new UsernameValidator();
            var userToBeTested = "Kalin Malinov";
            var minSymbols = 3;
            var maxSymbols = 30;


            //Act
            usernameValidator.IsUsernameValid(userToBeTested, minSymbols, maxSymbols);

            //There is no assert cause we expect Custom Exception to be thrown
        }

        [TestMethod]
        [TestCategory("UsernameValidationTests")]
        [ExpectedException(typeof(InvalidUsernameException), AllowDerivedTypes = true)]
        public void UserNameShouldThrowUsernameException_WhenContainSpecialChars()
        {
            //Arrange
            var usernameValidator = new UsernameValidator();
            var userToBeTested = "Br@nxo Br%an";
            var minSymbols = 5;
            var maxSymbols = 32;

            //Act
            usernameValidator.IsUsernameValid(userToBeTested, minSymbols, maxSymbols);

            //There is no assert cause we expect Custom Exception to be thrown
        }

        [TestMethod]
        [TestCategory("UsernameValidationTests")]
        [ExpectedException(typeof(InvalidUsernameException), AllowDerivedTypes = true)]
        public void UserNameShouldThrowUsernameException_WhenNameLenghtIsNotValid()
        {
            //Arange
            var usernameValidator = new UsernameValidator();
            var userTobeTested = "DjikimungliOChugwa";
            var minSymbols = 5;
            var maxSymbols = 10;

            //Act
            var actualResult = usernameValidator.IsUsernameValid(userTobeTested, minSymbols, maxSymbols);






        }




    }
}
