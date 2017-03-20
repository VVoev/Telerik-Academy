using System;

namespace InheritanceAndPolymorphism.Validations
{
    public static class Validator
    {
        public static void ValidateIfNull(string name,string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception($@"{value} cannot be null or empty");
            }

            if (name.Length < 3)
            {
                throw new Exception($@"{value} should be at least 3 symbols");
            }
        }
    }
}
