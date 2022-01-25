using ColorsSortAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsSortAsync
{
    public class ParallelSearcher<Tv>
        where Tv : struct
    {
        public SearchStep<GameBoard<Tv>> Tree;

        public ParallelSearcher(GameBoard<Tv> startStep)
        {
            Tree = new SearchStep<GameBoard<Tv>>(startStep);
        }


        public async Task<bool> Search()
        {
            return (await Search(Tree)).IsPositiveStep ?? false;
        }

        //private static HashSet<SearchStep<GameBoard<Tv>>> SearchStates = new HashSet<SearchStep<GameBoard<Tv>>>();
        private static ConcurrentDictionary<int, SearchStep<GameBoard<Tv>>> SearchStates = new ();

        private static async Task<SearchStep<GameBoard<Tv>>> Search(SearchStep<GameBoard<Tv>> step, ulong countRun = 0)
        {
            if (step is null || countRun >= ulong.MaxValue)
            {
                throw new ArgumentNullException(nameof(step));
            }

            Console.WriteLine($"{SearchStates.Count:D5} | {step}");

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
                step.IsPositiveStep ??= false;
                return step;
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

                    var compliteNextState = await Search(nextStep, ++countRun);
                    step.Child.Replace(nextStep, compliteNextState);
                    if (compliteNextState.IsPositiveStep ?? false)
                    {
                        step.IsPositiveStep = true;
                        return step;
                    }
                }
            }

            step.IsPositiveStep ??= false;
            return step;
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
