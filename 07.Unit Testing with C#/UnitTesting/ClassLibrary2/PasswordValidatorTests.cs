namespace UnitTesting.Validators.ValidatorTest
{
    using NUnit.Framework;
    using Validators.Exceptions;

    [TestFixture]
    public class PasswordValidatorTests
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

        [Test]
        [Category("PasswordValidation")]
        public void IsPasswordLenghtValid_ShouldReturnFalse_WhenPasswordLenghtIsGreaterThanMaxRequiredLenght()
        {
            //Arrange
            var passwordValidator = new PasswordValidator();
            var passwordToBeTested = $"P@s$worD";
            var minimumLen = 5;
            var maximumLen = 32;

            //Act
            var isPasswordLenghtValid = passwordValidator.IsPasswordValidLenghtValid(passwordToBeTested, minimumLen, maximumLen);

            //Assert
            Assert.IsFalse(isPasswordLenghtValid);
        }

        [TestCase(5, 12)]
        [TestCase(3, 52)]
        [TestCase(6, 44)]
        [TestCase(6, 500)]
        [Category("PasswordValidation")]
        public void IsPasswordLengehtValid_ShouldReturnTrue_WhenPasswordLenghtIsValid(int minPassLenght,int maxPassLenght)
        {
            //Arrange
            var passwordValidator = new PasswordValidator();
            var passwordToBeTested = "Iam$ouRSecR3TPassWord";
            var expectedResult = true;

            //Act
            var actualResult = passwordValidator.IsPasswordValidLenghtValid(passwordToBeTested, minPassLenght, maxPassLenght);

            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }


        [Test]
        [Category("PasswordValidation")]
        public void IsPasswordValid_ShouldThrowInvalidPasswordLenghtException_WhenPasswordLenghtIsNotValid()
        {
            //Arrange
            var passwordValidator = new PasswordValidator();
            var passwordToBeTested = "P@s%word!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
            var minRequiredPasswordLenght = 5;
            var maxRequiredPassWordLenght = 32;
            var minRequiredDigits = 1;
            var minRequiredUppercase = 4;
            var minRequiredLowerCase = 2;
            var minRequiredSpecialChars = 1;

            //Act 
            var ExcetionThrown = Assert.Throws<InvalidPasswordException>(
                () => passwordValidator.IsPasswordValid(
                    passwordToBeTested,
                    minRequiredPasswordLenght,
                    maxRequiredPassWordLenght,
                    minRequiredDigits,
                    minRequiredLowerCase,
                    minRequiredUppercase,
                    minRequiredSpecialChars));

            //Assert
            StringAssert.Contains("Password", ExcetionThrown.Message);
        }
    
    }
}
