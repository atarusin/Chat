using Breakfast.Cook;
using Breakfast.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Cook
{
    public class BreakfastParallel : AsyncCook
    {
        public static async Task Сooking()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<IEnumerable<Toast>> toastTask = MakeToastWithButterAndJamAsync(2);

            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are READY!");

            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is READY!");

            IEnumerable<Toast> toasts = await toastTask;
            Console.WriteLine($"{toasts.Count()} toast is READY!");

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task Сooking2()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Task[] tasks = new[] {
                    FryEggsAsync(2)
                        .ContinueWith(egg => {
                            Console.WriteLine("eggs are READY!"); }),
                    FryBaconAsync(3)
                        .ContinueWith(bacon => {
                            Console.WriteLine("bacon is READY!"); }),
                    MakeToastWithButterAndJamAsync(2)
                        .ContinueWith(toasts => {
                            Console.WriteLine($"{toasts.Result.Count()} toast is READY!"); })
                };
            await Task.WhenAll(tasks);

            Juice oj = PourOJ();
            Console.WriteLine("Juice is is READY!");
        }

        public static async Task BrokenСooking()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<IEnumerable<Toast>> toastTask = BrokeToastBreadAsync(2);//THROW InvalidOperationException

            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are READY!");

            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is READY!");

            IEnumerable<Toast> toasts = await toastTask;//Which throw exception this? 
            ApplyButter(toasts);
            ApplyJam(toasts);
            Console.WriteLine($"{toasts.Count()} toast is READY!");

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking2()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            var tasks = new Task[] {
                    FryEggsAsync(2)
                        .ContinueWith(egg => {
                            Console.WriteLine("eggs are READY!"); }),
                    FryBaconAsync(3)
                        .ContinueWith(bacon => {
                            Console.WriteLine("bacon is READY!"); }),
                    BrokeMakeToastWithButterAndJamAsync(2)//THROW InvalidOperationException
                        .ContinueWith(toasts => {
                            Console.WriteLine($"{toasts.Result.Count()} toast is READY!"); })//what will return the result?
                };
            await Task.WhenAll(tasks);//Which throw exception this? 

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking3()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            var tasks = new Task[] {
                    FryEggsAsync(2)
                        .ContinueWith(egg => {
                            Console.WriteLine("eggs are READY!");
                        }),
                    FryBaconAsync(3)
                        .ContinueWith(bacon => {
                            Console.WriteLine("bacon is READY!");
                        }),
                    BrokeMakeToastWithButterAndJamAsync(2)//THROW InvalidOperationException
                };
            await Task.WhenAll(tasks);//Which throw exception this?
            Console.WriteLine($"2 toast is READY!");

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking4()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            var tasks = new Task[] {
                    FryEggsAsync(2),
                    BrokeFryBaconAsync(3),//THROW Second InvalidOperationException
                    BrokeMakeToastWithButterAndJamAsync(2)//THROW First InvalidOperationException
                };
            await Task.WhenAll(tasks);//Which throw exception this? First or Second exception?
            Console.WriteLine("eggs are READY!");
            Console.WriteLine("bacon is READY!");
            Console.WriteLine($"2 toast is READY!");

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking5()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            var tasks = new Task[] {
                    FryEggsAsync(2),
                    BrokeMakeToastWithButterAndJamAsync(2),//THROW First InvalidOperationException
                    BrokeFryBaconAsync(3)//THROW Second InvalidOperationException
                };
            await Task.WhenAll(tasks);//Which throw exception this? First or Second exception?
            Console.WriteLine("eggs are READY!");
            Console.WriteLine("bacon is READY!");
            Console.WriteLine($"2 toast is READY!");

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking6()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Task taskOfFryEggs = FryEggsAsync(2);
            Task taskOfFryBacon = FryBaconAsync(3);
            Task taskOfMakeToast = BrokeMakeToastWithButterAndJamAsync(2);//THROW InvalidOperationException

            var list = new List<Task>() { taskOfFryEggs, taskOfFryBacon, taskOfMakeToast };
            while (list.Count > 0)
            {
                Task task = await Task.WhenAny(list);//Which throw exception this or there will be no exceptions?
                list.Remove(task);
                if (task == taskOfFryEggs)
                    Console.WriteLine("eggs are READY!");
                if (task == taskOfFryEggs)
                    Console.WriteLine("bacon is READY!");
                if (task == taskOfFryEggs)
                    Console.WriteLine($"toast is READY!");
            }

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking7()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Task taskOfFryEggs = FryEggsAsync(2);
            Task taskOfFryBacon = FryBaconAsync(3);
            Task taskOfMakeToast = BrokeMakeToastWithButterAndJamAsync(2);//THROW InvalidOperationException

            var list = new List<Task>() { taskOfFryEggs, taskOfFryBacon, taskOfMakeToast };
            while (list.Count > 0)
            {
                Task task = await Task.WhenAny(list);//Which throw exception this or there will be no exceptions? 
                list.Remove(task);

                if (task.Exception is not null)
                    throw task.Exception;//Which throw exception this? 

                if (task == taskOfFryEggs)
                    Console.WriteLine("eggs are READY!");
                if (task == taskOfFryEggs)
                    Console.WriteLine("bacon is READY!");
                if (task == taskOfFryEggs)
                    Console.WriteLine($"toast is READY!");
            }

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking8()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Task[] tasks = new[] {
                    FryEggsAsync(2)
                        .ContinueWith(egg => {
                            Console.WriteLine("eggs are READY!"); }),
                    BrokeFryBaconAsync(3)//THROW InvalidOperationException
                        .ContinueWith(bacon => {
                            Console.WriteLine("bacon is READY!"); }),
                    BrokeToastBreadAsync(2)//THROW InvalidOperationException
                        .ContinueWith(toasts => {

                            if (!toasts.IsCompletedSuccessfully)                                
                                //.Status=Faulted, .IsFaulted=true, IsCompleted=true, toasts.Exception is not null
                                return;

                            ApplyButter(toasts.Result);//what will return the result?
                            ApplyJam(toasts.Result);
                            Console.WriteLine($"{toasts.Result.Count()} toast is READY!"); })
                };
            await Task.WhenAll(tasks);//Which throw exception this or there will be no exceptions?

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking9()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Task[] tasks = new[] {
                    FryEggsAsync(2)
                        .ContinueWith(egg => {
                            Console.WriteLine("eggs are READY!"); }),
                    FryBaconAsync(3)
                        .ContinueWith(bacon => {
                            Console.WriteLine("bacon is READY!"); }),
                    BrokeToastBreadAsync(2)//THROW InvalidOperationException
                        .ContinueWith(toasts => {

                            if (toasts.Exception is not null)
                                throw toasts.Exception;//THROW

                            ApplyButter(toasts.Result);//what will return the result?
                            ApplyJam(toasts.Result);
                            Console.WriteLine($"{toasts.Result.Count()} toast is READY!"); })
                };
            await Task.WhenAll(tasks);//Which throw exception this? 

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }

        public static async Task BrokenСooking10()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is READY!");

            Task[] tasks = new[] {
                    FryEggsAsync(2)
                        .ContinueWith(egg => {
                            Console.WriteLine("eggs are READY!"); }),
                    FryBaconAsync(3)
                        .ContinueWith(bacon => {
                            Console.WriteLine("bacon is READY!"); }),
                    BrokeToastBreadAsync(2)//THROW InvalidOperationException
                        .ContinueWith(toasts => {
                            ApplyButter(toasts.Result);//what will return the result?
                            ApplyJam(toasts.Result);
                            Console.WriteLine($"{toasts.Result.Count()} toast is READY!");
                        }, TaskContinuationOptions.OnlyOnRanToCompletion)//what will this setting affect?
                };
            await Task.WhenAll(tasks);//Which throw exception this? 

            Juice oj = PourOJ();
            Console.WriteLine("Juice is READY!");
        }
    }
}