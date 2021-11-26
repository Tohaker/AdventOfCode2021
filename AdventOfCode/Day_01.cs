using AoCHelper;
using System.IO;

namespace AdventOfCode
{
    public class Day_01 : BaseDay
    {
        private readonly string _input;

        public Day_01()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");

        public override ValueTask<string> Solve_2() => new(Part2Async());

        private async Task<string> Part2Async()
        {
            Task.Delay(1000);
            return $"Solution to {ClassPrefix} {CalculateIndex()}, part 2";
        }
    }
}
