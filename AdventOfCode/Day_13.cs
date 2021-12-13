using AoCHelper;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_13 : BaseDay
    {
        private readonly string[] _input;

        public Day_13()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        public HashSet<Vector2> FoldPaper(string[] input, int folds = 0)
        {
            HashSet<Vector2> dots = new();
            List<(string, int)> foldList = new();

            foreach (var line in input)
            {
                if (line == "") continue;

                if (Regex.IsMatch(line, @"^\d"))
                {
                    var parts = line.Split(',');
                    dots.Add(new Vector2(int.Parse(parts[0]), int.Parse(parts[1])));
                }
                else
                {
                    var parts = line.Split("fold along ")[1].Split('=');
                    foldList.Add((parts[0], int.Parse(parts[1])));
                }
            }

            var foldListSubset = folds == 0 ? foldList : foldList.Take(folds);

            foreach (var (axis, value) in foldListSubset)
            {
                if (axis == "x")
                {
                    var pointsRightOfLine = dots.Where(v => v.X > value).ToArray();
                    foreach (var point in pointsRightOfLine)
                    {
                        var newX = point.X - 2 * (point.X - value);
                        dots.Add(new Vector2(newX, point.Y));
                        dots.RemoveWhere(v => v == point);
                    }
                }
                else
                {
                    var pointsAboveLine = dots.Where(v => v.Y > value).ToArray();
                    foreach (var point in pointsAboveLine)
                    {
                        var newY = point.Y - 2 * (point.Y - value);
                        dots.Add(new Vector2(point.X, newY));
                        dots.RemoveWhere(v => v == point);
                    }
                }
            }

            return dots;
        }

        public string PrintDots(HashSet<Vector2> dots)
        {
            var list = dots.ToList();
            var greatestX = dots.OrderBy(v => v.X).Last().X;
            var greatestY = dots.OrderBy(v => v.Y).Last().Y;

            string result = "";

            for (int y = 0; y <= greatestY; y++)
            {
                for (int x = 0; x <= greatestX; x++)
                {
                    if (dots.Contains(new Vector2(x, y))) result += "#";
                    else result += " ";
                }

                result += '\n';
            }

            return result;
        }

        public override ValueTask<string> Solve_1() => new(FoldPaper(_input, 1).Count.ToString());

        public override ValueTask<string> Solve_2() => new(PrintDots(FoldPaper(_input)));
    }
}
