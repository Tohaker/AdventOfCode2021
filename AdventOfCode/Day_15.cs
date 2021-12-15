using AoCHelper;
using System.Numerics;




namespace AdventOfCode
{
    using Graph = System.Collections.Generic.Dictionary<(int, int), Node>;

    class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Risk { get; set; }
        public int Distance { get; set; } = int.MaxValue;
        public bool Visited { get; set; } = false;

        public Node(int x, int y, int risk)
        {
            X = x;
            Y = y;
            Risk = risk;
        }
    }

    public class Day_15 : BaseDay
    {
        private readonly string[] _input;
        static (int, int)[] adjacent = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        public Day_15()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        public int FindLowestRiskPath(string[] input)
        {
            var next = new PriorityQueue<Node, int>();
            var graph = new Graph();

            int height = input.Count();
            int width = input[0].Length;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    graph.Add((x, y), new Node(x, y, input[y][x] - '0'));
                }
            }

            graph[(0, 0)].Distance = 0;
            next.Enqueue(graph[(0, 0)], 0);
            var target = graph[(width - 1, height - 1)];

            while (next.Count > 0)
            {
                // Find node with min distance from current
                var current = next.Dequeue();
                if (current.Visited) continue;

                // Remove from the list of uncovered nodes
                current.Visited = true;

                if (current == target) return target.Distance;

                // Find neighbours to current
                var neighbours = new List<Node>();
                foreach ((int i, int j) in adjacent)
                {
                    var key = (current.X + i, current.Y + j);
                    if (graph.ContainsKey(key) && !graph[key].Visited)
                    {
                        neighbours.Add(graph[key]);
                    }
                }

                foreach (var n in neighbours)
                {
                    var alt = current.Distance + n.Risk;
                    if (alt < n.Distance)
                    {
                        n.Distance = alt;
                    }

                    if (n.Distance != int.MaxValue)
                    {
                        next.Enqueue(n, n.Distance);
                    }
                }
            }

            return target.Distance;
        }

        public string[] ExpandMap(string[] input)
        {
            List<string> expanded = new();

            // Expand horizontally
            foreach (var line in input)
            {
                string newLine = line;
                for (int i = 1; i < 5; i++)
                {
                    string segment = "";
                    foreach (char c in line)
                    {
                        int val = c - '0';
                        int newVal = val + i > 9 ? i - (9 - val) : val + i;
                        segment += newVal;
                    }
                    newLine += segment;
                }
                expanded.Add(newLine);
            }

            var curr = expanded.ToArray();

            // Expand Vertically
            for (int i = 1; i < 5; i++)
            {
                foreach (var line in curr)
                {
                    string newLine = "";
                    foreach (char c in line)
                    {
                        int val = c - '0';
                        int newVal = val + i > 9 ? i - (9 - val) : val + i;
                        newLine += newVal;
                    }

                    expanded.Add(newLine);
                }
            }

            return expanded.ToArray();
        }

        public override ValueTask<string> Solve_1() => new(FindLowestRiskPath(_input).ToString());

        public override ValueTask<string> Solve_2() => new(FindLowestRiskPath(ExpandMap(_input)).ToString());
    }
}
