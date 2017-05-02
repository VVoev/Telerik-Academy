namespace SchoolSystem.CLI.Models.Abstraction
{
    using Constants;
    using Contracts;
    using System.Text.RegularExpressions;
    using Exceptions;

    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (!Regex.Match(value, Constant.RegexPattern).Success)
                {
                    throw new NameExceptions($@"{value} does not match our policy");
                }

                if (value.Length < Constant.NameMinLenght || value.Length > Constant.NameMaxLenght)
                {
                    throw new NameExceptions($@"{value} should be between {Constant.NameMinLenght} and {Constant.NameMaxLenght} symbols long");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (!Regex.Match(value, Constant.RegexPattern).Success)
                {
                    throw new NameExceptions($@"{value} does not match our policy");
                }

                if (value.Length < Constant.NameMinLenght || value.Length > Constant.NameMaxLenght)
                {
                    throw new NameExceptions($@"{value} should be between {Constant.NameMinLenght} and {Constant.NameMaxLenght} symbols long");
                }

                this.lastName = value;
            }
        }
    }
}
