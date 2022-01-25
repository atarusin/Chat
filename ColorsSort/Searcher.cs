using ColorsSort.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ColorsSort
{
    public class Searcher<Tv>
        where Tv : struct
    {
        public SearchStep<GameBoard<Tv>> Tree;

        public Searcher(GameBoard<Tv> startStep)
        {
            Tree = new SearchStep<GameBoard<Tv>>(startStep);
        }


        public bool Search()
        {
            return Search(ref Tree);
        }

        private static object loc = new();
        protected static ConcurrentDictionary<int, int> UsegeThreads = new();

        protected static void WriteToConsole(SearchStep<GameBoard<Tv>> step)
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"{SearchStates.Count:D5} | Th:{currentThread.ManagedThreadId} | CL= {Task.Factory.Scheduler?.MaximumConcurrencyLevel} | {step}");
        }

        //private static HashSet<SearchStep<GameBoard<Tv>>> SearchStates = new HashSet<SearchStep<GameBoard<Tv>>>();
        protected static ConcurrentDictionary<int, SearchStep<GameBoard<Tv>>> SearchStates = new ();

        private static bool Search(ref SearchStep<GameBoard<Tv>> step, ulong countRun = 0)
        {
            if (step is null || countRun >= ulong.MaxValue)
            {
                throw new ArgumentNullException(nameof(step));
            }

            WriteToConsole(step);

            if (!SearchStates.TryAdd(step.GetHashCode(), step) 
                && SearchStates.TryGetValue(step.GetHashCode(), out var similarStep))
            {
                step.IsPositiveStep = similarStep.IsPositiveStep ?? false;
                //if (similarStep.IsPositiveStep is null && step.IsEquelOrChildFor(similarStep))
                //{
                //    step.IsPositiveStep = false;
                //}
            }

            if (step.IsPositiveStep is null && IsFound(step.CurrentState))
            {
                step.IsPositiveStep = true;
            }

            if (IsFinished(step))
            {
                return step.IsPositiveStep ?? false;
            }

            foreach (ColorSet<Tv> from in step.CurrentState.Sets)
            {
                if (from.IsEmpty())
                {
                    continue;
                }

                foreach (ColorSet<Tv> to in step.CurrentState.Sets)
                {
                    if (!ColorSet<Tv>.IsCanMoveColor(from, to))
                    {
                        continue;
                    }
                    var fromCopy = from.CopyTo();
                    var toCopy = to.CopyTo();
                    if (!ColorSet<Tv>.MoveColor(ref fromCopy, ref toCopy))
                    {
                        continue;
                    }
                    var nextState = step.CurrentState.CopyTo();
                    nextState.Sets.Replace(from, fromCopy);
                    nextState.Sets.Replace(to, toCopy);
                    var nextStep = new SearchStep<GameBoard<Tv>>(nextState, step);
                    step.Child.Add(nextStep);

                    if (Search(ref nextStep, ++countRun))
                    {
                        step.IsPositiveStep = true;
                        return true;
                    }
                }
            }

            return step.IsPositiveStep ??= false;
        }

        public static bool IsFound(GameBoard<Tv> state)
        {
            return !state.Sets.Any() ||
                state.Sets.All(s => s.IsEmpty() || s.IsFully() && s.IsOnlyOneColor());
        }

        public static bool IsFinished(SearchStep<GameBoard<Tv>> step)
        {
            return step.IsPositiveStep is not null;
        }
    }
}
