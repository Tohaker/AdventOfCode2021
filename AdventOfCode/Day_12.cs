using AoCHelper;

namespace AdventOfCode
{
    public class Day_12 : BaseDay
    {
        private readonly string[] _input;

        public Day_12()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        private Dictionary<string, List<string>> ParseInput(string[] input)
        {
            Dictionary<string, List<string>> result = new();

            foreach (var line in input)
            {
                var parts = line.Split('-');

                if (!result.ContainsKey(parts[0])) result[parts[0]] = new();
                if (!result.ContainsKey(parts[1])) result[parts[1]] = new();

                if (parts[0] != "end" && parts[1] != "start") result[parts[0]].Add(parts[1]);
                if (parts[1] != "end" && parts[0] != "start") result[parts[1]].Add(parts[0]);
            }

            return result;
        }

        public List<List<string>> FindAllPaths(string[] input, bool explorationAllowed)
        {
            Queue<(string, List<string>, HashSet<string>, bool)> explore = new();
            List<List<string>> paths = new();

            var connections = ParseInput(input);

            explore.Enqueue(("start", new(), new(), false));

            do
            {
                (string pos, List<string> path, HashSet<string> visited, bool twoVisits) = explore.Dequeue();
                path.Add(pos);

                if (pos == "end")
                {
                    paths.Add(path);
                    continue;
                }

                visited.Add(pos);

                foreach (string nextPos in connections[pos])
                {
                    bool nextSmall = nextPos[0] > 96 && nextPos != "end", nextTwo = twoVisits;
                    if (visited.Contains(nextPos) && nextSmall)
                    {
                        if (!explorationAllowed || nextTwo) continue;
                        nextTwo = true;
                    }
                    explore.Enqueue((nextPos, new(path), new(visited), nextTwo));
                }

            } while (explore.Count > 0);

            return paths;
        }

        public override ValueTask<string> Solve_1() => new(FindAllPaths(_input, false).Count.ToString());

        public override ValueTask<string> Solve_2() => new(FindAllPaths(_input, true).Count.ToString());
    }
}
