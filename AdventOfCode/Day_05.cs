using AoCHelper;
using System.Numerics;

namespace AdventOfCode
{
    public static class Sequence
    {
        public static IEnumerable<int> Range(int start, int end)
        {
            int current = start;
            if (start > end)
            {
                while (current >= end)
                {
                    yield return current--;
                }
            }
            else
            {
                while (current <= end)
                {
                    yield return current++;
                }
            }
        }
    }

    public readonly struct Coords
    {
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; init; }
        public int Y { get; init; }

        public bool Equals(Coords other) => X == other.X && Y == other.Y;

        public override int GetHashCode() => HashCode.Combine(X, Y);
    }

    public class OceanFloor
    {
        public Dictionary<Vector2, int> ventMap { get; }

        public OceanFloor(string[] input, bool horizontalOnly)
        {
            ventMap = new Dictionary<Vector2, int>();

            foreach (var line in input)
            {
                var coords = ParseInputLine(line, horizontalOnly);

                foreach (var point in coords)
                {
                    var count = ventMap.TryGetValue(point, out var value) ? value + 1 : 1;
                    if (count > 1) ventMap[point] = count;
                    else ventMap.Add(point, count);
                }
            }
        }

        public int CountOverlappingVents() => ventMap.Values.Where(v => v > 1).Count();

        private List<Vector2> ParseInputLine(string line, bool horizontalOnly)
        {
            var parts = line.Split(" -> ");
            var start = parts[0].Split(',');
            var end = parts[1].Split(',');

            var startX = int.Parse(start[0]);
            var startY = int.Parse(start[1]);
            var endX = int.Parse(end[0]);
            var endY = int.Parse(end[1]);

            var result = new List<Vector2>();

            // Ignore diagonals here
            var isDiagonal = startX != endX && startY != endY;

            if (isDiagonal)
            {
                if (horizontalOnly)
                    return result;
                else
                {
                    IEnumerable<int> xRange = Sequence.Range(startX, endX);
                    IEnumerable<int> yRange = Sequence.Range(startY, endY);

                    return xRange.Zip(yRange, (x, y) => new Vector2(x, y)).ToList();
                }
            }

            if (startX == endX)
            {
                IEnumerable<int> yRange = Sequence.Range(startY, endY);
                IEnumerable<int> xRange = Enumerable.Repeat(startX, yRange.Count());

                return xRange.Zip(yRange, (x, y) => new Vector2(x, y)).ToList();
            }

            if (startY == endY)
            {
                IEnumerable<int> xRange = Sequence.Range(startX, endX);
                IEnumerable<int> yRange = Enumerable.Repeat(startY, xRange.Count());

                return xRange.Zip(yRange, (x, y) => new Vector2(x, y)).ToList();
            }

            return result;
        }
    }

    public class Day_05 : BaseDay
    {
        private readonly string[] _input;

        public Day_05()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        public override ValueTask<string> Solve_1()
        {
            OceanFloor floor = new OceanFloor(_input, true);

            return new(floor.CountOverlappingVents().ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            OceanFloor floor = new OceanFloor(_input, false);

            return new(floor.CountOverlappingVents().ToString());
        }
    }
}
