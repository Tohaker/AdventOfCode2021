using AoCHelper;

namespace AdventOfCode
{
    public class Day_04 : BaseDay
    {
        private readonly string _input;

        public Day_04()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() => new("Solution 1");

        public override ValueTask<string> Solve_2() => new("Solution 2");
    }
}
