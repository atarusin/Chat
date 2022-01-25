using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsSort
{
    public class SearchStep<T>
    {
        private SearchStep() { }

        public SearchStep(T currentState) : this(currentState, null) { }

        public SearchStep(T currentState, SearchStep<T> parent)
        {
            CurrentState = currentState;
            Parent = parent;
            Child = new List<SearchStep<T>>();
        }

        public T CurrentState { get; private set; }

        public bool? IsPositiveStep { get; set; } = null;

        public IList<SearchStep<T>> Child { get; private set; }

        public SearchStep<T> Parent { get; private set; }

        public uint Level
        {
            get
            {
                return (Parent?.Level ?? 0) + 1;
            }
        }

        public override string ToString()
        {
            return $"isOk: {IsPositiveStep}, Level: {Level}, {CurrentState.ToString()}, {GetHashCode()}";
        }

        public override int GetHashCode()
        {
            return CurrentState.GetHashCode();
        }
    }
}
