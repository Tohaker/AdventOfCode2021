using AoCHelper;

namespace AdventOfCode
{
    public class Day_09 : BaseDay
    {
        private readonly string[] _input;

        public Day_09()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        public int FindLowPoints(string[] input)
        {
            List<List<int>> caves = new List<List<int>>();
            int riskLevel = 0;

            int rowLength = input[0].Length + 2;
            caves.Add(Enumerable.Repeat(9, rowLength).ToList());

            foreach (var line in input)
            {
                List<int> row = Array.ConvertAll(line.ToCharArray(), c => c - '0').ToList();
                row.Insert(0, 9);
                row.Add(9);
                caves.Add(row);
            }

            caves.Add(Enumerable.Repeat(9, rowLength).ToList());

            int bottomRow = caves.Count() - 1;

            for (int i = 1; i < bottomRow; i++)
            {
                var row = caves[i];
                for (int j = 1; j < rowLength - 1; j++)
                {
                    var current = row[j];

                    // Check adjacent points
                    if (row[j + 1] > current && row[j - 1] > current && caves[i + 1][j] > current && caves[i - 1][j] > current)
                        riskLevel += current + 1;
                }

            }

            return riskLevel;
        }

        public override ValueTask<string> Solve_1() => new(FindLowPoints(_input).ToString());

        public override ValueTask<string> Solve_2() => new("Solution 2");
    }
}
