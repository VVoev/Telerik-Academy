namespace UnitTesting.Validators.Validators.Exceptions
{
    using System;
    public class InvalidPasswordException : ArgumentException
    {
        public InvalidPasswordException(string msg)
            :base(msg)
        {

        }
    }
}
