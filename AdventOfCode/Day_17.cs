using AoCHelper;
using System.Numerics;

namespace AdventOfCode
{
    public class Day_17 : BaseDay
    {
        private readonly string _input;

        public Day_17()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public int FindHighestY(string input)
        {
            // Parse input
            var parts = input.Remove(0, 13).Split(", ");
            var yRange = parts[1].Remove(0, 2).Split("..");

            var yStart = int.Parse(yRange[0]);
            var yEnd = int.Parse(yRange[1]);

            return Enumerable.Range(1, Math.Abs(Math.Min(yStart, yEnd)) - 1).Sum();
        }

        public override ValueTask<string> Solve_1() => new(FindHighestY(_input).ToString());

        public override ValueTask<string> Solve_2() => new("Solution 2");
    }
}
