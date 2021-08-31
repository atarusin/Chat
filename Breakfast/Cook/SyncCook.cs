using Breakfast.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Cook
{
    public class SyncCook
    {
        protected static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        protected static void ApplyJam(IEnumerable<Toast> toasts) =>
            Console.WriteLine($"Putting jam on the {toasts.Count()} toasts");

        protected static void ApplyButter(IEnumerable<Toast> toasts) =>
            Console.WriteLine($"Putting butter on the {toasts.Count()} toast");

        protected static IEnumerable<Toast> ToastBread(int slices)
        {
            var toasts = new List<Toast>();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            for (int slice = 0; slice < slices;)
            {
                Console.WriteLine("Start toasting...");
                Task.Delay(3000).Wait();

                toasts.Add(new Toast());
                slice++;
                if (slice < slices)
                {
                    toasts.Add(new Toast());
                    slice++;
                }
                Console.WriteLine("Remove toast from toaster");
            }
            return toasts;
        }

        protected static IEnumerable<Toast> MakeToastWithButterAndJam(int number)
        {
            IEnumerable<Toast> toasts = ToastBread(number);
            ApplyButter(toasts);
            ApplyJam(toasts);

            return toasts;
        }

        protected static IEnumerable<Toast> BrokeToastBread(int slices)
        {
            var toasts = new List<Toast>();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(2000).Wait();
            Console.WriteLine("Fire! Toast is ruined!");
            throw new InvalidOperationException("The toaster is on FIRE!!!");
            Task.Delay(1000).Wait();
            Console.WriteLine("Remove toast from toaster");
            return toasts;
        }

        protected static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        protected static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        protected static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}