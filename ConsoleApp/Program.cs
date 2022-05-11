using Breakfast;
using Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskAsyncParallel;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.GetInfo());
            Console.WriteLine();

            //await new ConcurrentRun().RunAsync();

            //ThreadsExemple.SettingsToConsole();
            //await CookingExamples.Run();
            await CookingExceptionExamples.Run();
            //TaskStatusExample.Run();

            Console.ReadKey();
        }
    }
}
