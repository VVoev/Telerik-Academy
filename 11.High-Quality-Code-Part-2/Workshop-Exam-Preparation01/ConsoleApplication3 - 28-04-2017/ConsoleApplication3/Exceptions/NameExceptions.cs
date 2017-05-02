namespace SchoolSystem.CLI.Exceptions
{
    using System;

    public class NameExceptions : ArgumentException
    {
        public NameExceptions(string message)
            : base(message)
        {
        }
    }
}
