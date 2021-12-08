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
        public Dictionary<string, int> DetermineSegmentCodes(string[] _input)
        {
            List<string> input = _input.ToList();

            // Setup initial facts
            string one = input.Where(s => s.Length == 2).First();
            string seven = input.Where(s => s.Length == 3).First();
            string four = input.Where(s => s.Length == 4).First();
            string eight = input.Where(s => s.Length == 7).First();

            // Remove from the list
            foreach (var num in new string[] { one, seven, four, eight })
                input.RemoveAt(input.FindIndex(s => s == num));

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
                    input.RemoveAt(input.FindIndex(s => s == code));
                    break;
                }
            }

            // Find code for digit 3
            var threeArray = one.ToCharArray().Append(segments['A']).Append(segments['G']);

            foreach (var code in input.Where(s => s.Length == 5))
            {
                var leftover = code.ToCharArray().Except(threeArray);

                if (leftover.Count() == 1)
                {
                    segments.Add('D', leftover.First());
                    codes.Add(code, 3);
                    input.RemoveAt(input.FindIndex(s => s == code));
                    break;
                }
            }

            // Calculate segment E
            char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            var nineCode = codes.First(e => e.Value == 9).Key.ToCharArray();
            var remainingChar = letters.Except(nineCode).First();
            segments.Add('E', remainingChar);

            // Find code for digit 0
            foreach (var code in input.Where(s => s.Length == 6))
            {
                if (!code.ToCharArray().Contains(segments['D']))
                {
                    codes.Add(code, 0);
                    input.RemoveAt(input.FindIndex(s => s == code));
                    break;
                }
            }

            // Find code for digit 2
            char[] twoArray = new char[] { segments['A'], segments['D'], segments['E'], segments['G'] };

            foreach (var code in input.Where(s => s.Length == 5))
            {
                var leftovers = code.ToCharArray().Except(twoArray);
                if (leftovers.Count() == 1)
                {
                    segments.Add('C', leftovers.First());
                    var fVal = codes.First(e => e.Value == 1).Key.ToCharArray().Except(leftovers).First();
                    segments.Add('F', fVal);
                    codes.Add(code, 2);
                    input.RemoveAt(input.FindIndex(s => s == code));
                    break;
                }
            }

            // Find code for digit 5
            char[] fiveArray = new char[] { segments['A'], segments['D'], segments['F'], segments['G'] };
            foreach (var code in input.Where(s => s.Length == 5))
            {
                var leftovers = code.ToCharArray().Except(fiveArray);
                if (leftovers.Count() == 1)
                {
                    segments.Add('B', leftovers.First());
                    codes.Add(code, 5);
                    input.RemoveAt(input.FindIndex(s => s == code));
                    break;
                }
            }

            // Find code for digit 6
            codes.Add(input.First(), 6);

            return codes;
        }

        public int CalculateTotalDisplay(string[] input)
        {
            int total = 0;

            foreach (var line in input)
            {
                var parts = ParseLine(line);

                var examples = DetermineSegmentCodes(parts.Item1);

                int multiplyer = 1000;
                int subtotal = 0;

                foreach (var code in parts.Item2)
                {
                    var codeArray = code.ToCharArray().OrderBy(c => c);
                    int value = examples.Where(e => e.Key.ToCharArray().OrderBy(c => c).SequenceEqual(codeArray)).First().Value;

                    subtotal += value * multiplyer;
                    multiplyer /= 10;
                }

                total += subtotal;
            }

            return total;
        }

        public override ValueTask<string> Solve_1() => new(CountUniqueDigits(_input).ToString());

        public override ValueTask<string> Solve_2() => new(CalculateTotalDisplay(_input).ToString());
    }
}
