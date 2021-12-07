using AoCHelper;

namespace AdventOfCode
{
    public class Day_07 : BaseDay
    {
        private readonly string _input;

        public Day_07()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() => new("Solution 1");

        public override ValueTask<string> Solve_2() => new("Solution 2");
    }
}
