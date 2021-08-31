using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ErrorExtension
    {
        public static string ToLogInfo<T>(this T ex) where T : Exception
        {
            var sb = new StringBuilder();
            ex.ToLogInfo(ref sb);
            return sb.ToString();
        }

        private static void ToLogInfo<T>(this T ex, ref StringBuilder sb, uint level = 0) where T : Exception
        {
            if (ex is null)
            {
                return;
            }
            sb.AppendLine($"EROR ( {level} inner level): {ex.ToString()}");
            ex.InnerException.ToLogInfo(ref sb, level + 1);
            if (ex is AggregateException)
                foreach (var innerEx in (ex as AggregateException).InnerExceptions)
                    innerEx.ToLogInfo(ref sb, level + 1);
        }
    }
}
