
namespace UnitTesting.Validators
{
    using System;
    using System.Linq;
    using Validators.Exceptions;
    using Validators.Helpers;

    public class UserNameValidator
    {
        public bool IsUSernameValid(string username,int minRequiredUsernameLenght,int maxRequiredUsernameLenght)
        {
            if (!this.UsernameIsValid(username, minRequiredUsernameLenght, maxRequiredUsernameLenght))
            {
                throw new InvalidUsernameException($"Username must be between {minRequiredUsernameLenght} and {maxRequiredUsernameLenght} symbols");
            }
            if (this.HasWhiteSpace(username))
            {
                throw new InvalidUsernameException($"Username cannot contain white spaces");
            }
            if (this.HasSpecialChars(username))
            {
                throw new InvalidUsernameException($"Username cannot contain special chars");
            }
            return true;
        }

        private bool UsernameIsValid(string username, int minRequiredUsernameLenght, int maxRequiredUsernameLenght)
        {
            return username.Length >= minRequiredUsernameLenght && username.Length <= maxRequiredUsernameLenght;
        }

        private bool HasWhiteSpace(string username)
        {
            return username.Any(x => char.IsWhiteSpace(x));
        }

        private bool HasSpecialChars(string username)
        {
            return username.Any(x => CharHelper.IsSpecialChar(x));
        }
    }
}
