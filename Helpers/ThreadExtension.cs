using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ThreadExtension
    {
        public static string GetInfo(this Thread thread, ThreadInfoEnum properties = ThreadInfoEnum.ManagedThreadId 
                | ThreadInfoEnum.IsBackground 
                | ThreadInfoEnum.IsThreadPoolThread)
        {
            System.Dynamic.ExpandoObject info = new ();
            var valueSet = (IDictionary<String, Object>)info;
            if (properties.HasFlag(ThreadInfoEnum.Name))
            {
                valueSet.TryAdd(ThreadInfoEnum.Name.ToString(), thread.Name);
            }
            if (properties.HasFlag(ThreadInfoEnum.ManagedThreadId))
            {
                valueSet.TryAdd(ThreadInfoEnum.ManagedThreadId.ToString(), thread.ManagedThreadId);
            }
            if (properties.HasFlag(ThreadInfoEnum.GetHashCode))
            {
                valueSet.TryAdd(ThreadInfoEnum.GetHashCode.ToString(), thread.GetHashCode());
            }
            if (properties.HasFlag(ThreadInfoEnum.IsBackground))
            {
                valueSet.TryAdd(ThreadInfoEnum.IsBackground.ToString(), thread.IsBackground);
            }
            if (properties.HasFlag(ThreadInfoEnum.IsAlive))
            {
                valueSet.TryAdd(ThreadInfoEnum.IsAlive.ToString(), thread.IsAlive);
            }
            if (properties.HasFlag(ThreadInfoEnum.IsThreadPoolThread))
            {
                valueSet.TryAdd(ThreadInfoEnum.IsThreadPoolThread.ToString(), thread.IsThreadPoolThread);
            }
            if (properties.HasFlag(ThreadInfoEnum.Priority))
            {
                valueSet.TryAdd(ThreadInfoEnum.Priority.ToString(), thread.Priority.ToString());
            }
            if (properties.HasFlag(ThreadInfoEnum.ApartmentState))
            {
                valueSet.TryAdd(ThreadInfoEnum.ApartmentState.ToString(), thread.ApartmentState.ToString());
            }
            if (properties.HasFlag(ThreadInfoEnum.ThreadState))
            {
                valueSet.TryAdd(ThreadInfoEnum.ThreadState.ToString(), thread.ThreadState.ToString());
            }
            if (properties.HasFlag(ThreadInfoEnum.CurrentCulture))
            {
                valueSet.TryAdd(ThreadInfoEnum.CurrentCulture.ToString(), thread.CurrentCulture.ToString());
            }
            if (properties.HasFlag(ThreadInfoEnum.CurrentUICulture))
            {
                valueSet.TryAdd(ThreadInfoEnum.CurrentUICulture.ToString(), thread.CurrentUICulture.ToString());
            }
            return $"Thread info JSON: {JsonSerializer.Serialize(info)}";
        } 
    }
}
