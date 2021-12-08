using AoCHelper;

namespace AdventOfCode
{
    public class Day_08 : BaseDay
    {
        private readonly string[] _input;

        public Day_08()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        private (string[], string[]) ParseLine(string line)
        {
            var parts = line.Split(" | ");

            return (parts[0].Split(), parts[1].Split());
        }

        public int CountUniqueDigits(string[] input)
        {
            int count = 0;
            int[] uniqueDigitLengths = new int[] { 2, 3, 4, 7 };

            foreach (var line in input)
            {
                count += ParseLine(line).Item2.Where(s => uniqueDigitLengths.Contains(s.Length)).Count();
            }

            return count;
        }

        public override ValueTask<string> Solve_1() => new(CountUniqueDigits(_input).ToString());

        public override ValueTask<string> Solve_2() => new("Solution 2");
    }
}
