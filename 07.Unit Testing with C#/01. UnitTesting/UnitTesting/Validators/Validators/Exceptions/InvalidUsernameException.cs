namespace UnitTesting.Validators.Validators.Exceptions
{
    using System;

    public class InvalidUsernameException : ArgumentException
    {
        public InvalidUsernameException(string msg)
            :base(msg)
        {

        }
    }
}
