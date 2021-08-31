using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Watcher
    {
        public static async Task Of(Func<Task> func, string description)
        {
            Console.WriteLine($"{description}");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {

                await func();

                stopWatch.Stop();
            }
            catch (InvalidOperationException ex)
            {
                stopWatch.Stop();
                Console.WriteLine(ex.ToLogInfo());
            }
            catch (AggregateException ex)
            {
                stopWatch.Stop();
                Console.WriteLine(ex.ToLogInfo());
            }
            catch (TaskCanceledException ex)
            {
                stopWatch.Stop();
                Console.WriteLine(ex.ToLogInfo());
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                Console.WriteLine(ex.ToLogInfo());
            }
            Console.WriteLine($"Breakfast is ready {stopWatch.Elapsed}!");
            Console.ReadKey();
        }

        public static void Of(Action action, string description)
        {
            Console.WriteLine($"{description}");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {

                action();

                stopWatch.Stop();
            }
            catch (InvalidOperationException ex)
            {
                stopWatch.Stop();
                Console.WriteLine(ex.ToLogInfo());
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                Console.WriteLine(ex.ToLogInfo());
            }
            Console.WriteLine($"Breakfast is ready {stopWatch.Elapsed}!");
            Console.ReadKey();
        }
    }
}
