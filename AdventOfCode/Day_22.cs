using AoCHelper;

namespace AdventOfCode
{
    public class Day_22 : BaseDay
    {
        private readonly string _input;

        public Day_22()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() => new("Solution 1");

        public override ValueTask<string> Solve_2() => new("Solution 2");
    }
}
