using Breakfast.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Cook
{
    public class AsyncCook
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

        protected static async Task<IEnumerable<Toast>> ToastBreadAsync(int slices)
        {
            var toasts = new List<Toast>();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            for (int slice = 0; slice < slices;)
            {
                Console.WriteLine("Start toasting...");
                await Task.Delay(3000);

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

        protected static async Task<IEnumerable<Toast>> MakeToastWithButterAndJamAsync(int number)
        {
            IEnumerable<Toast> toasts = await ToastBreadAsync(number);
            ApplyButter(toasts);
            ApplyJam(toasts);

            return toasts;
        }

        protected static async Task<IEnumerable<Toast>> BrokeToastBreadAsync(int slices)
        {
            var toasts = new List<Toast>();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(2000);
            Console.WriteLine("THROW \t\t Fire! Toast is ruined!");
            throw new InvalidOperationException("The toaster is on FIRE!!!");
            await Task.Delay(1000);
            Console.WriteLine("Remove toast from toaster");
            return toasts;
        }

        protected static async Task<IEnumerable<Toast>> BrokeMakeToastWithButterAndJamAsync(int number)
        {
            IEnumerable<Toast> toasts = await BrokeToastBreadAsync(number);
            ApplyButter(toasts);
            ApplyJam(toasts);

            return toasts;
        }

        protected static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        protected static async Task<Bacon> BrokeFryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("THROW \t\t Burnt! The bacons is BURNT!!!");
            throw new InvalidOperationException("The bacons is BURNT!!!");
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        protected static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
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