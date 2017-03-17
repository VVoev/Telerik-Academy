using Abstraction.Exceptions;

namespace Abstraction.Validations
{
    public static class Validator
    {
        public static void ValidateIfPositive(double value, string name)
        {
            if (value < 0)
            {
                throw new FigureException($@"{name} cannot negative");
            }
        }
    }
}
