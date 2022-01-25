using ColorsSort.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ColorsSort
{
    public class ParallelAsyncSearcher<Tv> : Searcher<Tv>
        where Tv : struct
    {
        public ParallelAsyncSearcher(GameBoard<Tv> startStep) : base(startStep)
        {
        }

        public async Task<bool> SearchAsync()
        {
            return (await SearchAsync(Tree).ConfigureAwait(false)).IsPositiveStep ?? false;
        }

        private static async Task<SearchStep<GameBoard<Tv>>> SearchAsync(SearchStep<GameBoard<Tv>> step, ulong countRun = 0)
        {
            if (step is null || countRun >= ulong.MaxValue)
            {
                throw new ArgumentNullException(nameof(step));
            }

            WriteToConsole(step);

            if (!SearchStates.TryAdd(step.GetHashCode(), step)
                && SearchStates.TryGetValue(step.GetHashCode(), out var similarStep))
            {
                step.IsPositiveStep = false;
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

            List<Task<SearchStep<GameBoard<Tv>>>> tasks = new();

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

                    var newTask = SearchAsync(nextStep, ++countRun).ContinueWith(r =>
                    {
                        var compliteNextState = r.Result;

                        return compliteNextState;
                    }, TaskContinuationOptions.RunContinuationsAsynchronously);
                    tasks.Add(newTask);
                }
            }

            var res = await Task.WhenAll(tasks);
            if (res.Any(s => s?.IsPositiveStep ?? false))
            {
                step.IsPositiveStep = true;
            }
            step.IsPositiveStep ??= false;
            
            return step;
        }
    }
}
