using StudentApplication.Constantsss;
using StudentApplication.Validators;

namespace StudentApplication.Abstract
{
    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Validator.ValidateNameIsInRange(Constants.NameMinLenght, Constants.NameMaxLenght, value);
                Validator.ValidateIfNull(value);
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
                Validator.ValidateNameIsInRange(Constants.NameMinLenght, Constants.NameMaxLenght, value);
                Validator.ValidateIfNull(value);
                this.firstName = value;
            }
        }
    }
}
