using AoCHelper;

namespace AdventOfCode
{
    public class Day_08 : BaseDay
    {
        private readonly string[] _input;

        public Day_08()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        private (string[], string[]) ParseLine(string line)
        {
            var parts = line.Split(" | ");

            return (parts[0].Split(), parts[1].Split());
        }

        public int CountUniqueDigits(string[] input)
        {
            int count = 0;
            int[] uniqueDigitLengths = new int[] { 2, 3, 4, 7 };

            foreach (var line in input)
            {
                count += ParseLine(line).Item2.Where(s => uniqueDigitLengths.Contains(s.Length)).Count();
            }

            return count;
        }

        /**
        *  AAAA
        * B    C
        * B    C
        *  DDDD
        * E    F
        * E    F
        *  GGGG
        */
        public Dictionary<string, int> DetermineSegmentCodes(string[] input)
        {
            // Setup initial facts
            string one = input.Where(s => s.Length == 2).First();
            string seven = input.Where(s => s.Length == 3).First();
            string four = input.Where(s => s.Length == 4).First();
            string eight = input.Where(s => s.Length == 7).First();

            Dictionary<string, int> codes = new Dictionary<string, int>() {
                {one, 1},
                {four, 4},
                {seven, 7},
                {eight, 8}
            };

            Dictionary<char, char> segments = new Dictionary<char, char>();

            // Calculate segment A
            char aVal = seven.ToCharArray().Except(one.ToCharArray()).First();
            segments.Add('A', aVal);

            // Find code for digit 9
            var nineArray = four.ToCharArray().Append(aVal);

            foreach (var code in input.Where(s => s.Length == 6))
            {
                var leftover = code.ToCharArray().Except(nineArray);

                if (leftover.Count() == 1)
                {
                    segments.Add('G', leftover.First());
                    codes.Add(code, 9);
                    break;
                }
            }

            return codes;
        }

        public override ValueTask<string> Solve_1() => new(CountUniqueDigits(_input).ToString());

        public override ValueTask<string> Solve_2() => new("Solution 2");
    }
}
