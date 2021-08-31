using Breakfast.Cook;
using Helpers;
using System.Threading.Tasks;

namespace Breakfast
{
    public static class CookingExceptionExamples
    {
        /// <summary>
        /// Cook breakfast (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static async Task Run()
        {
            Watcher.Of(BreakfastSync.BrokenCooking, "\n\t COOK Sync breakfast");

            await Watcher.Of(BreakfastAsync.BrokenСooking, "\n\t COOK Async breakfast");

            await Watcher.Of(BreakfastParallel.BrokenСooking, "\n\t COOK Parallel 1 of way breakfast:");
            await Watcher.Of(BreakfastParallel.BrokenСooking2, "\n\t COOK Parallel 2 of way breakfast:");
            await Watcher.Of(BreakfastParallel.BrokenСooking3, "\n\t COOK Parallel 3 of way breakfast:");
            await Watcher.Of(BreakfastParallel.BrokenСooking4, "\n\t COOK Parallel 4 of way breakfast:");
            await Watcher.Of(BreakfastParallel.BrokenСooking5, "\n\t COOK Parallel 5 of way breakfast:");
            await Watcher.Of(BreakfastParallel.BrokenСooking6, "\n\t COOK Parallel 6 of way breakfast:");
            await Watcher.Of(BreakfastParallel.BrokenСooking7, "\n\t COOK Parallel 7 of way breakfast:");
            await Watcher.Of(BreakfastParallel.BrokenСooking8, "\n\t COOK Parallel 8 of way breakfast:");
            await Watcher.Of(BreakfastParallel.BrokenСooking9, "\n\t COOK Parallel 9 of way breakfast:");
            await Watcher.Of(BreakfastParallel.BrokenСooking10, "\n\t COOK Parallel 9 of way breakfast:");
        }
    }
}
