using System;

namespace CohesionAndCoupling.Validations
{
    public static class Validator
    {
        public static void ValidateIfNegative(double value, string name)
        {
            if (value < 0)
            {
                throw new Exception($@"{name} should be positive");
            }
        }
    }
}
