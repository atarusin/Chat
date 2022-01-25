using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsSort.Extensions
{
    public static class IListExtension
    { 
        public static IList<T> Replace<T>(this IList<T> list, T fromItem, T toItem)
        {
            int i = list.IndexOf(fromItem);
            list.Remove(fromItem);
            list.Insert(i, toItem);
            return list;
        }
    }
}
