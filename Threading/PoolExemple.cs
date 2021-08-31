using System;
using System.Threading;

namespace Threading
{
    public static class PoolExemple
    {
        public static void SettingsToConsole()
        {
            ThreadPool.GetMaxThreads(out var maxThreads, out var maxIoPortThreads);
            Console.WriteLine($"{maxThreads} - The maximum number of worker threads in the thread pool.");
            Console.WriteLine($"{maxIoPortThreads} - The maximum number of asynchronous I/O threads in the thread pool");

            ThreadPool.GetAvailableThreads(out var availableThreads, out var availablePortThreads);
            Console.WriteLine($"{availableThreads} - The number of available worker threads.");
            Console.WriteLine($"{availablePortThreads} - The number of available asynchronous I/O threads.");

            Console.WriteLine($"{ThreadPool.ThreadCount} - Thread Count at Exists threads poll.");

        }
    }
}
