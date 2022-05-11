using Breakfast.Cook;
using Breakfast.Entity;
using System;

namespace Breakfast.Cook
{
    /// <summary>
    /// A class in which var is deliberately used to declare variables with a non-obvious method return type. 
    /// If you use asynchronous methods AsyncCookMistake class instead of synchronous methods class SyncCook 
    /// we get disturbed sequence of preparing breakfast, but visually it is not obvious!
    /// </summary>
    public class BreakfastSync : SyncCook //AsyncCookMistake
    {
        public static void Cooking()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            var eggs = FryEggs(2);
            Console.WriteLine("eggs are READY!");

            var bacon = FryBacon(3);
            Console.WriteLine("bacon is READY!");

            var toasts = MakeToastWithButterAndJam(2);
            Console.WriteLine($"2 toast is READY!");

            Juice oj = PourOJ();
            Console.WriteLine("oj is READY!");
        }

        public static void BrokenCooking()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            var eggs = FryEggs(2);
            Console.WriteLine("eggs are READY!");

            var bacon = FryBacon(3);
            Console.WriteLine("bacon is READY!");

            var toasts = BrokeToastBread(2);
            ApplyButter(toasts);
            ApplyJam(toasts);
            Console.WriteLine($"2 toast is READY!");

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }
    }
}