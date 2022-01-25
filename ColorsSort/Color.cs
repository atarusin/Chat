using System;

namespace ColorsSort
{
    public record Color<T> where T : struct
    {
        public Color(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
