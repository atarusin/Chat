using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsSort
{
    public record GameBoard<T> where T : struct
    {
        public GameBoard() { 
            Sets = new ValueSet<ColorSet<T>>();
        }

        public GameBoard(IList<ColorSet<T>> sets)
        {
            Sets = new ValueSet<ColorSet<T>>();
            foreach (var item in sets.Select(v => v))
            {
                Sets.Add(item);
            }
        }

        public GameBoard(GameBoard<T> gameBoard)
        {
            Sets = new ValueSet<ColorSet<T>>();
            foreach (var item in gameBoard.Sets.Select(v => v))
            {
                Sets.Add(item);
            }
        }

        public readonly ValueSet<ColorSet<T>> Sets;

        public GameBoard<T> CopyTo() => new GameBoard<T>(this);

        public override string ToString()
        {
            return $"{string.Join(",", Sets.Select(s => s.ToString()))}".ToString();
        }

        public override int GetHashCode()
        {
            return $"{string.Join(",", Sets.OrderBy(s => s.GetHashCode()))}".GetHashCode();
        }

        //public override bool Equals(object obj)
        //{
        //    return this.GetHashCode() == obj?.GetHashCode();
        //}

    }
}
