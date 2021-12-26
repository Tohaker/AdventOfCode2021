using AoCHelper;

namespace AdventOfCode
{
    public class Day_26 : BaseDay
    {
        private readonly string _input;

        public Day_26()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() => new("Solution 1");

        public override ValueTask<string> Solve_2() => new("Solution 2");
    }
}
