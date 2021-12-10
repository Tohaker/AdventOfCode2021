using AoCHelper;

namespace AdventOfCode
{
    public class Day_10 : BaseDay
    {
        private readonly string[] _input;

        public Day_10()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        public char FindFirstIllegalCharacter(string line)
        {
            Stack<char> stack = new Stack<char>();
            char[] closingChars = new char[] { ')', '}', ']', '>' };

            foreach (char c in line.ToCharArray())
            {
                if (!closingChars.Contains(c))
                {
                    stack.Push(c);
                    continue;
                }

                var lastOpened = stack.Peek();

                switch (lastOpened)
                {
                    case '(':
                        if (c == ')') stack.Pop();
                        else return c;
                        break;
                    case '[':
                        if (c == ']') stack.Pop();
                        else return c;
                        break;
                    case '{':
                        if (c == '}') stack.Pop();
                        else return c;
                        break;
                    case '<':
                        if (c == '>') stack.Pop();
                        else return c;
                        break;
                    default:
                        break;
                }
            }

            return 'a';
        }

        public List<char> CompleteUnfinishedLine(string line)
        {
            Stack<char> stack = new Stack<char>();
            char[] closingChars = new char[] { ')', '}', ']', '>' };
            Dictionary<char, char> correspondingChars = new Dictionary<char, char>() {
                {'(', ')'},
                {'{', '}'},
                {'[', ']'},
                {'<', '>'}
            };

            foreach (char c in line.ToCharArray())
            {
                if (!closingChars.Contains(c))
                {
                    stack.Push(c);
                    continue;
                }

                var lastOpened = stack.Peek();

                switch (lastOpened)
                {
                    case '(':
                        if (c == ')') stack.Pop();
                        break;
                    case '[':
                        if (c == ']') stack.Pop();
                        break;
                    case '{':
                        if (c == '}') stack.Pop();
                        break;
                    case '<':
                        if (c == '>') stack.Pop();
                        break;
                    default:
                        break;
                }
            }

            List<char> result = new List<char>();

            foreach (char c in stack.AsEnumerable())
            {
                result.Add(correspondingChars[c]);
            }

            return result;
        }

        public int CountIllegalCharacters(string[] input)
        {
            int count = 0;

            Dictionary<char, int> scores = new Dictionary<char, int>() {
                {')', 3},
                {']', 57},
                {'}', 1197},
                {'>', 25137},
                {'a', 0}
            };

            foreach (var line in input)
            {
                count += scores[FindFirstIllegalCharacter(line)];
            }

            return count;
        }

        public long CountAutocompletedCharacters(string[] input)
        {
            List<long> counts = new List<long>();

            Dictionary<char, int> scores = new Dictionary<char, int>() {
                {')', 1},
                {']', 2},
                {'}', 3},
                {'>', 4},
            };

            foreach (var line in input)
            {
                var c = FindFirstIllegalCharacter(line);
                long count = 0;

                if (c == 'a')
                {
                    var chars = CompleteUnfinishedLine(line);

                    foreach (var ch in chars)
                    {
                        count *= 5;
                        count += scores[ch];
                    }
                }

                if (count > 0) counts.Add(count);
            }

            counts.Sort();

            return counts[(counts.Count() / 2)];
        }

        public override ValueTask<string> Solve_1() => new(CountIllegalCharacters(_input).ToString());

        public override ValueTask<string> Solve_2() => new(CountAutocompletedCharacters(_input).ToString());
    }
}
