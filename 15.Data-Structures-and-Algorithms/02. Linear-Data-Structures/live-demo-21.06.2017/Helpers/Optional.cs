using System;

namespace Helpers
{
    public class Optional<T>
    {
        private class Box
        {
            public T Value { get; set; }
        }

        private Box box;

        public Optional()
        {
            box = null;
        }

        public Optional(T value)
        {
            box = new Box();
            box.Value = value;
        }

        public bool HasValue => box != null;

        public Optional<T> WithValue(Action<T> func)
        {
            if (HasValue)
            {
                func(box.Value);
            }

            return this;
        }

        public void Else(Action func)
        {
            if (!HasValue)
            {
                func();
            }
        }

        public Optional<R> WithValue<R>(Func<T, R> func)
        {
            if(HasValue)
            {
                return new Optional<R>(func(box.Value));
            }
            else
            {
                return new Optional<R>();
            }
        }
    }
}
