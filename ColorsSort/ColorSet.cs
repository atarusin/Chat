using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsSort
{
    public record ColorSet<T>
        where T : struct
    {
        private ColorSet() { }

        public ColorSet(uint count)
        {
            Values = new ValueList<Color<T>>();
            Count = count;
        }

        public ColorSet(IList<Color<T>> colors, uint? count)
            : this(count ?? (uint)colors.Count)
        {
            foreach (var color in colors.Take((int)Count))
            {
                Values.Add(color);
            }
        }

        public ColorSet(ColorSet<T> colorSet)
        {
            Values = new ValueList<Color<T>>();
            Count = colorSet.Count;
            foreach (var color in colorSet.Colors.Take((int)Count))
            {
                Values.Add(color);
            }
        }

        private readonly ValueList<Color<T>> Values;

        //public IReadOnlyList<Color<T>> Colors { get => (IReadOnlyList<Color<T>>)Values; }

        public IReadOnlyList<Color<T>> Colors { get => (IReadOnlyList<Color<T>>)Values; }

        public uint Count { get; private set; }

        public override string ToString()
        {
            return $"{{ Count:{Count}, Value:[{string.Join(", ", Colors)}] }}";
        }

        public override int GetHashCode()
        {
            return $"{Count}:{string.Join(",", Colors)}".GetHashCode();
        }

        public bool IsEmpty() => Values.Count == default;

        public bool IsFully() => (ulong)Values.Count == Count;

        public bool IsOnlyOneColor() => Values.Aggregate<Color<T>, Color<T>?, bool>(
            Values.First(),
            (agr, item) =>
            {
                return (agr is null || agr.Value.Equals(item.Value) ?
                    agr :
                    null);
            },
            (agr) => agr is not null);

        public bool Add(Color<T> value)
        {
            if (!IsCanAdd(value))
            {
                return false;
            }

            Values.Add(value);
            return true;
        }

        private bool IsCanAdd(Color<T> value)
        {
            return value != null &&
                !IsFully() &&
                (IsEmpty() || value.Equals(Values.LastOrDefault()));
        }

        public ColorSet<T> CopyTo() => new ColorSet<T>(this);

        public static bool IsCanMoveColor(ColorSet<T> from, ColorSet<T> to)
        {
            return !object.ReferenceEquals(from, to) &&
                !from.IsEmpty() &&
                to.IsCanAdd(from.Values.LastOrDefault());
        }

        public static bool MoveColor(ref ColorSet<T> from, ref ColorSet<T> to)
        {
            int fromCount = from.Values.Count;
            int toCount = to.Values.Count;
            while (to.Add(from.Values.LastOrDefault()))
            {
                from.Values.RemoveAt(from.Values.Count - 1);
            }
            return fromCount != from.Values.Count || toCount != to.Values.Count;
        }
    }
}
