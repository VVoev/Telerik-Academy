namespace _03.RangeExceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException where T : IComparable<T>
    {
        public InvalidRangeException(T start, T end)
            : base("The value is outside of defined boundaries")
        {
            this.Start = start;
            this.End = end;

        }

        public T Start { get; set; }

        public T End { get; set; }
    }
}
