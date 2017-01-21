namespace UnitTesting.Validators
{
    using System.Linq;

    using Validators.Exceptions;
    using Validators.Helpers;

    public class PasswordValidator
    {
        public bool IsPasswordValid(
            string password,
            int minRequiredPasswordLenght,
            int maxRequiredPasswordLenght,
            int minRequiredDigitsCount,
            int minRequiredLowerCaseCount,
            int minRequiredUpperCaseCount,
            int minRequiredSpecialCharsCount)
        {
            if (!this.IsPasswordValidLenghtValid(password, minRequiredPasswordLenght, maxRequiredPasswordLenght))
            {
                throw new InvalidPasswordException($"Password lenght must be between {minRequiredPasswordLenght} and {maxRequiredPasswordLenght}");
            }
            if (!this.PasswordHasDigits(password,minRequiredDigitsCount))
            {
                throw new InvalidPasswordException($"Password must contain at least  {minRequiredDigitsCount}");
            }
            if (!this.PasswordsHasLowerCaseLetters(password, minRequiredLowerCaseCount))
            {
                throw new InvalidPasswordException($"Password must have at least {minRequiredLowerCaseCount} lowercase count");
            }
            if (!this.PasswordsHasUpperCaseLetters(password, minRequiredUpperCaseCount))
            {
                throw new InvalidPasswordException($"Password must have at least {maxRequiredPasswordLenght} uppercase count");
            }
            if (!this.PAsswordHasSpecialChars(password,minRequiredSpecialCharsCount))
            {
                throw new InvalidPasswordException($"Password must have at least {minRequiredSpecialCharsCount} special chars count");
            }
            return true;
        }

        public bool PasswordsHasLowerCaseLetters(string password, int minRequiredLowerCaseCount)
        {
            return password.Where(x => char.IsLetter(x) && char.IsLower(x)).Count() >= minRequiredLowerCaseCount;
        }

        public bool PasswordsHasUpperCaseLetters(string password, int minRequiredUpperCaseCount)
        {
            return password.Where(x => char.IsLetter(x) && char.IsUpper(x)).Count() >= minRequiredUpperCaseCount;
        }

        public bool PAsswordHasSpecialChars(string password, int minRequiredSpecialCharsCount)
        {
            return password.Where(x => CharHelper.IsSpecialChar(x)).Count() >= minRequiredSpecialCharsCount;
        }

        public bool PasswordHasDigits(string password, int minRequiredDigitsCount)
        {
            return password.Where(x => char.IsDigit(x)).Count() >= minRequiredDigitsCount;
        }

        public bool IsPasswordValidLenghtValid(string password, int minRequiredPasswordLenght, int maxRequiredPasswordLenght)
        {
            return password.Length >= minRequiredPasswordLenght && password.Length <= maxRequiredPasswordLenght;
        }
    }
}
