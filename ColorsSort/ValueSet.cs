using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsSort
{
    public class ValueSet<T> : List<T>, IEquatable<ValueSet<T>>
    {
        public bool Equals(ValueSet<T> other)
        {
            return this.OrderBy(v => v.GetHashCode()).SequenceEqual(other.OrderBy(v => v.GetHashCode()));
        }
    }
}
