using System;

namespace Abstraction.Exceptions
{
    public class FigureException : Exception
    {
        public FigureException(string message)
            : base(message)
        {
        }
    }
}
