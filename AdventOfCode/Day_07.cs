using AoCHelper;

namespace AdventOfCode
{
    public class Day_07 : BaseDay
    {
        private readonly int[] _input;

        public Day_07()
        {
            _input = Array.ConvertAll(File.ReadAllText(InputFilePath).Split(','), s => int.Parse(s));
        }

        public int CheapestFuel(int[] input)
        {
            Array.Sort(input);

            int middle = input.Count() / 2;
            int median = input[middle];

            int total = 0;
            foreach (var crab in input)
            {
                total += Math.Abs(crab - median);
            }

            return total;
        }

        public int CheapestFuelAvg(int[] input)
        {
            double average = ((double)input.Sum() / (double)input.Count());
            int lowerBoundAvg = ((int)Math.Round(average - .5));
            int upperBoundAvg = ((int)Math.Round(average + .5));

            var totals = (0, 0);
            foreach (var crab in input)
            {
                int lowerSubtotal = 0;
                int upperSubtotal = 0;
                for (int i = 1; i <= (Math.Abs(crab - lowerBoundAvg)); i++)
                {
                    lowerSubtotal += i;
                }

                for (int i = 1; i <= (Math.Abs(crab - upperBoundAvg)); i++)
                {
                    upperSubtotal += i;
                }

                totals.Item1 += lowerSubtotal;
                totals.Item2 += upperSubtotal;
            }

            return totals.Item1 > totals.Item2 ? totals.Item2 : totals.Item1;
        }

        public override ValueTask<string> Solve_1() => new(CheapestFuel(_input).ToString());

        public override ValueTask<string> Solve_2() => new(CheapestFuelAvg(_input).ToString());
    }
}
