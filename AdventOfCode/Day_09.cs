using AoCHelper;
using System.Numerics;

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

        public int FindBasins(string[] input)
        {
            List<List<int>> caves = new List<List<int>>();
            List<Vector2> lowPoints = new List<Vector2>();
            List<int> basins = new List<int>();

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
                    if (row[j + 1] > current && row[j - 1] > current && caves[i + 1][j] > current && caves[i - 1][j] > current)
                        lowPoints.Add(new Vector2(j, i));
                }
            }

            foreach (var point in lowPoints)
            {
                List<Vector2> _points = new List<Vector2>();
                _points.Add(point);

                for (int i = 0; i < _points.Count; i++)
                {
                    CheckAndAdd((int)_points[i].X + 1, (int)_points[i].Y, ref _points, ref caves);
                    CheckAndAdd((int)_points[i].X - 1, (int)_points[i].Y, ref _points, ref caves);
                    CheckAndAdd((int)_points[i].X, (int)_points[i].Y - 1, ref _points, ref caves);
                    CheckAndAdd((int)_points[i].X, (int)_points[i].Y + 1, ref _points, ref caves);
                }

                basins.Add(_points.Count());
            }

            basins.Sort();

            return basins[^1] * basins[^2] * basins[^3];
        }

        private void CheckAndAdd(int x, int y, ref List<Vector2> _points, ref List<List<int>> caves)
        {
            if (caves[y][x] != 9)
            {
                foreach (var var in _points)
                {
                    if (var.X == x && var.Y == y) return;
                }
                _points.Add(new Vector2(x, y));
            }
        }

        public override ValueTask<string> Solve_1() => new(FindLowPoints(_input).ToString());

        public override ValueTask<string> Solve_2() => new(FindBasins(_input).ToString());
    }
}
