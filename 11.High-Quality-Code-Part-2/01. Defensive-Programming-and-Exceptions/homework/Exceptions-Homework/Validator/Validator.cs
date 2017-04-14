using System;
using System.Collections.Generic;
using System.Linq;

namespace Exceptions_Homework.Validator
{
    public static class Validator
    {
        public static void IsStringNullOrEmptry(string value,string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($@"${name} cannot be null or empty");
            }
        }

        public static void IsArrayNullOrEmpty<T>(IEnumerable<T> value)
        {
            if(value == null)
            {
                throw new ArgumentNullException("Array cannot be null");
            }

            if (value.Count() == 0)
            {
                throw new ArgumentNullException("Array is empty");
            }
        }

        public static void IsNumberNegative(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number is Neggative");
            }
        }
    }
}
