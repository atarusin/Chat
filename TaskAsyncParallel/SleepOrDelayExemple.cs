using Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadsExamples.Examples
{
    public static class SleepOrDelayExemple
    {
        /// <summary>
        /// This method keeps the current thread
        /// </summary>
        public static void RunSync()
        {
            Thread.Sleep(5000);
        }

        /// <summary>
        /// This method starts the task and await completed it and does not keep the current thread
        /// </summary>
        /// <returns></returns>
        public static async Task RunAwaitAsync()
         {
            await Task.Delay(new TimeSpan(0, 0, 5));
        }

        /// <summary>
        /// This method only start the task and does not await completed task
        /// </summary>
        /// <returns></returns>
        public static Task RunNotAwaitAsync()
        {
            Task task = Task.Delay(new TimeSpan(0, 0, 5));
            return task;
        }
    }
}
