using AoCHelper;

namespace AdventOfCode
{
    public class Day_01 : BaseDay
    {
        private readonly int[] _input;

        public Day_01()
        {
            _input = Array.ConvertAll(File.ReadAllText(InputFilePath).Split('\n'), s => int.Parse(s));
        }

        public int CalculateDepthIncreases(int[] input)
        {
            int count = 0;
            int previous = -1;

            foreach (var depth in input)
            {
                if ((previous > 0) && (depth > previous))
                {
                    count++;
                }

                previous = depth;
            }

            return count;
        }

        public int CalculateCumulativeDepthIncreases(int[] input)
        {
            var windows = new List<int>();

            for (int i = 0; i < input.Length - 2; i++)
            {
                windows.Add(input[i] + input[i + 1] + input[i + 2]);

                // A slower but more functional way could be to use ArraySegments and Sum accumulators
                // var segment = (new ArraySegment<int>(input, i, 3)).Sum();
                // windows.Add(segment);
            }

            return CalculateDepthIncreases(windows.ToArray());
        }

        public override ValueTask<string> Solve_1() => new(CalculateDepthIncreases(_input).ToString());

        public override ValueTask<string> Solve_2() => new(CalculateCumulativeDepthIncreases(_input).ToString());
    }
}
