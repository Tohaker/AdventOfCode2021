using AoCHelper;

namespace AdventOfCode
{
    public class BingoCard
    {
        public int[][] card { get; }
        public bool[][] marked { get; }

        public BingoCard(string[] input)
        {
            card = new int[5][];
            marked = new bool[5][];

            int i = 0;
            foreach (string line in input)
            {
                string[] splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] lineNumbers = Array.ConvertAll(splitLine, s => int.Parse(s.Trim()));

                card.SetValue(lineNumbers, i);
                marked.SetValue(new bool[5], i);
                i++;
            }
        }

        public void MarkNumber(int value)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (card[i][j] == value)
                    {
                        marked[i][j] = true;
                        return;
                    }
                }
            }
        }

        public int[] CheckLines()
        {
            for (int i = 0; i < 5; i++)
            {
                // Check rows first
                if (marked[i].All(b => b)) return card[i];

                bool[] col = new bool[5];
                // Check each column
                for (int j = 0; j < 5; j++)
                {
                    bool isMarked = marked[j][i];

                    // Drop out early if one of the values isn't marked
                    if (!isMarked) break;

                    col[j] = isMarked;
                }

                if (col.Length == 5 && col.All(b => b))
                {
                    int[] colVals = new int[5];

                    for (int k = 0; k < 5; k++)
                    {
                        colVals[k] = card[k][i];
                    }

                    return colVals;
                }
            }

            return new int[0];
        }

        public int UnmarkedNumbers()
        {
            int result = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!marked[i][j]) result += card[i][j];
                }
            }

            return result;
        }
    }

    public class Day_04 : BaseDay
    {
        private readonly string[] _input;

        public Day_04()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n').Where(l => l != "").ToArray();
        }

        private int[] GetDrawOrder(string[] input) => Array.ConvertAll(input[0].Split(','), s => int.Parse(s));

        private List<BingoCard> GetBingoCards(string[] input)
        {
            List<BingoCard> cards = new List<BingoCard>();

            for (int i = 1; i < input.Length; i += 5)
            {
                cards.Add(new BingoCard(new ArraySegment<string>(input, i, 5).ToArray()));
            }

            return cards;
        }

        public int PlayBingo(string[] input)
        {
            int[] drawOrder = GetDrawOrder(input);
            List<BingoCard> cards = GetBingoCards(input);

            foreach (var draw in drawOrder)
            {
                foreach (var card in cards)
                {
                    card.MarkNumber(draw);
                    var line = card.CheckLines();

                    if (line.Length == 5)
                    {
                        return card.UnmarkedNumbers() * draw;
                    }
                }
            }

            return 0;
        }

        public int PlayUntilLastBingoCard(string[] input)
        {
            int[] drawOrder = GetDrawOrder(input);
            List<BingoCard> cards = GetBingoCards(input);

            HashSet<BingoCard> winners = new HashSet<BingoCard>();

            foreach (var draw in drawOrder)
            {
                foreach (var card in cards)
                {
                    card.MarkNumber(draw);
                    var line = card.CheckLines();

                    if (line.Length == 5)
                    {
                        // Card has now won
                        winners.Add(card);

                        if (winners.Count == cards.Count)
                        {
                            return winners.Last().UnmarkedNumbers() * draw;
                        }
                    }
                }
            }

            return 0;
        }

        public override ValueTask<string> Solve_1()
        {
            var result = PlayBingo(_input);

            return new(result.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var result = PlayUntilLastBingoCard(_input);

            return new(result.ToString());
        }
    }
}
