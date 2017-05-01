namespace StudentApplication.Validators
{
    using System;

    public static class Validator
    {
        public static void ValidateNameIsInRange(int min, int max, string name)
        {
            if (name.Length < min || name.Length > max)
            {
                throw new ArgumentException($@"{name} is not in range");
            }
        }

        public static void ValidateIfNull(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($@"{name} cannot be null or empty");
            }
        }
    }
}
