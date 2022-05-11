using Breakfast.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Cook
{
    public class BreakfastAsync : AsyncCook
    {
        public static async Task Сooking()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("eggs are READY!");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("bacon is READY!");

            IEnumerable<Toast> toasts = await ToastBreadAsync(2);
            ApplyButter(toasts);
            ApplyJam(toasts);
            Console.WriteLine($"{toasts.Count()} toast is READY!");

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("eggs are READY!");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("bacon is READY!");

            IEnumerable<Toast> toasts = await BrokeToastBreadAsync(2);
            ApplyButter(toasts);
            ApplyJam(toasts);
            Console.WriteLine($"{toasts.Count()} toast is READY!");

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }
    }
}