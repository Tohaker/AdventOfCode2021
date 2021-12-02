using AoCHelper;

namespace AdventOfCode
{
    public class Day_02 : BaseDay
    {
        private readonly string[] _input;

        public Day_02()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        public (int, int) MoveCartesian(string[] commands)
        {
            var result = (0, 0);

            foreach (var command in commands)
            {
                var parts = command.Split(' ');
                var dir = parts[0];
                var dist = int.Parse(parts[1]);

                switch (dir)
                {
                    case "forward":
                        result = (result.Item1 + dist, result.Item2);
                        break;
                    case "up":
                        result = (result.Item1, result.Item2 - dist);
                        break;
                    case "down":
                        result = (result.Item1, result.Item2 + dist);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        public (int, int) MoveWithAim(string[] commands)
        {
            var result = (0, 0);
            var aim = 0;

            foreach (var command in commands)
            {
                var parts = command.Split(' ');
                var dir = parts[0];
                var dist = int.Parse(parts[1]);

                switch (dir)
                {
                    case "forward":
                        result = (result.Item1 + dist, result.Item2 + aim * dist);
                        break;
                    case "up":
                        aim -= dist;
                        break;
                    case "down":
                        aim += dist;
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        public override ValueTask<string> Solve_1()
        {
            var position = MoveCartesian(_input);

            return new((position.Item1 * position.Item2).ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var position = MoveWithAim(_input);

            return new((position.Item1 * position.Item2).ToString());
        }
    }
}
