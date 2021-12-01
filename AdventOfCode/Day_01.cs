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

        public override ValueTask<string> Solve_1()
        {
            int[] input = Array.ConvertAll(_input.Split('\n'), s => int.Parse(s));

            return new(CalculateDepthIncreases(input).ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            int[] input = Array.ConvertAll(_input.Split('\n'), s => int.Parse(s));

            return new(CalculateCumulativeDepthIncreases(input).ToString());
        }
    }
}
