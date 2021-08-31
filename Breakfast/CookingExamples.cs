using Breakfast.Cook;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast
{
    public static class CookingExamples
    {
        /// <summary>
        /// Cook breakfast (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static async Task Run()
        {
            Watcher.Of(BreakfastSync.Cooking, "\n\t COOK Sync breakfast");

            await Watcher.Of(BreakfastAsync.Сooking, "\n\t COOK Async breakfast");

            await Watcher.Of(BreakfastParallel.Сooking, "\n\t COOK Parallel 1 of way breakfast");
            await Watcher.Of(BreakfastParallel.Сooking2, "\n\t COOK Parallel 2 of way breakfast");
        }
    }
}
