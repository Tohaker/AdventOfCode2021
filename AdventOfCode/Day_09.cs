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

            foreach (var line in input)
            {
                List<int> row = Array.ConvertAll(line.ToCharArray(), c => c - '0').ToList();
                caves.Add(row);
            }

            int bottomRow = caves.Count() - 1;

            for (int i = 0; i <= bottomRow; i++)
            {
                var row = caves[i];
                var rowLen = row.Count() - 1;
                for (int j = 0; j < row.Count(); j++)
                {
                    var current = row[j];
                    if (i == 0)
                    {
                        // Check adjacent points
                        if ((j == 0 && row[j + 1] > current && caves[i + 1][j] > current)
                        || (j == rowLen && row[j - 1] > current && caves[i + 1][j] > current)
                        || (j > 0 && j < rowLen && row[j + 1] > current && row[j - 1] > current && caves[i + 1][j] > current))
                            riskLevel += current + 1;
                    }
                    else if (i == bottomRow)
                    {
                        // Check adjacent points
                        if ((j == 0 && row[j + 1] > current && caves[i - 1][j] > current)
                        || (j == rowLen && row[j - 1] > current && caves[i - 1][j] > current)
                        || (j > 0 && j < rowLen && row[j + 1] > current && row[j - 1] > current && caves[i - 1][j] > current))
                            riskLevel += current + 1;
                    }
                    else
                    {
                        // Check adjacent points
                        if ((j == 0 && row[j + 1] > current && caves[i + 1][j] > current && caves[i - 1][j] > current)
                        || (j == rowLen && row[j - 1] > current && caves[i + 1][j] > current && caves[i - 1][j] > current)
                        || (j > 0 && j < rowLen && row[j + 1] > current && row[j - 1] > current && caves[i + 1][j] > current && caves[i - 1][j] > current))
                            riskLevel += current + 1;
                    }
                }

            }

            return riskLevel;
        }

        public override ValueTask<string> Solve_1() => new(FindLowPoints(_input).ToString());

        public override ValueTask<string> Solve_2() => new("Solution 2");
    }
}
