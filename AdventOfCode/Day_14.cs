using AoCHelper;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_14 : BaseDay
    {
        private readonly string[] _input;

        public Day_14()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        public long FindElementQuantities(string[] input, int steps)
        {
            var template = input[0];
            var rules = input.Skip(2).Select(l => l.Split(" -> ")).ToDictionary(r => r[0], r => r[1][0]);

            // Find how many of each pair is in the template
            var pairs = rules.ToDictionary(r => r.Key, r => new Regex(r.Key).Matches(template).LongCount());

            // Count how many of each character is currently in the template
            var chars = Enumerable.Range(0, 26).Select(i => (char)('A' + i)).ToDictionary(c => c, c => template.LongCount(t => t == c));


            for (int i = 0; i < steps; i++)
            {
                // Include the count of values already in the template
                foreach (var rule in rules)
                    chars[rule.Value] += pairs[rule.Key];

                pairs = rules.ToDictionary(r => r.Key,
                    r => rules
                    // Add the rule's value in the middle of itself, and check if it contains itself at all
                    .Where(x => x.Key.Insert(1, x.Value.ToString()).Contains(r.Key))
                    // The value of each rule is the total number of pairs already counted
                    .Sum(x => pairs[x.Key]));
            }

            var elements = chars.Where(c => c.Value > 0).OrderBy(d => d.Value);

            return elements.Last().Value - elements.First().Value;
        }

        public override ValueTask<string> Solve_1() => new(FindElementQuantities(_input, 10).ToString());

        public override ValueTask<string> Solve_2() => new(FindElementQuantities(_input, 40).ToString());
    }
}
