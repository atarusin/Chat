using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    [Flags]
    public enum ThreadInfoEnum
    {
        Empty,
        Name,
        ManagedThreadId,
        GetHashCode,
        IsBackground,
        IsAlive,
        IsThreadPoolThread,
        Priority,
        ApartmentState,
        ThreadState,
        CurrentCulture,
        CurrentUICulture
    }
}
