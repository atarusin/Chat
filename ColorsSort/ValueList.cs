using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsSort
{
    public class ValueList<T> : List<T>, IEquatable<ValueList<T>>
    {
        public bool Equals(ValueList<T> other)
        {
            return this.SequenceEqual(other);
        }
    }
}
