using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsSort.Extensions
{
    public static class SearchStepExtension
    {
        public static bool IsEquelOrChildFor<T>(this SearchStep<T> item, SearchStep<T> parent)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (parent == item)
            {
                return true;
            }
            if (!parent.Child.Any())
            {
                return false;
            }
            foreach (var nextParent in parent.Child)
            {
                if (item.IsEquelOrChildFor(nextParent))
                {
                    return true;
                }
            }
            return false;
        }


        public static string Print<T>(this Searcher<T> searcher) where T : struct
        {
            if (searcher is null)
            {
                throw new ArgumentNullException(nameof(searcher));
            }
            var i = 1;
            return string.Join("\n***\n", GetAllFound(searcher.Tree)
                .Select(s =>
                        (s is null) ? $"result: {i++}\n" : $"level:{s.Level} - {s.IsPositiveStep} \n" + string.Join("\n", s?.CurrentState.Sets)
            ));
        }

        private static List<SearchStep<T>> GetAllFound<T>(this SearchStep<T> item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            List<SearchStep<T>> founds = new();
            if (item.Child != null && item.Child.Any())
            {
                foreach (var child in item.Child)
                {
                    founds.AddRange(GetAllFound(child));
                }
            }
            else if (item.IsPositiveStep ?? false)
            {
                founds.AddRange(item.GetAllParents());
                founds.Add(null);
                return founds;
            }

            return founds;
        }

        private static List<SearchStep<T>> GetAllParents<T>(this SearchStep<T> item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (item.Parent is null)
            {
                return new() { item };
            }
            var list = GetAllParents(item.Parent);
            list.Add(item);
            return list;
        }
    }
}
