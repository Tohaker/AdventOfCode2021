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
            double a = ((double)input.Sum() / (double)input.Count());
            int avg = ((int)Math.Round(a));

            int total = 0;
            foreach (var crab in input)
            {
                int subtotal = 0;
                for (int i = 1; i <= (Math.Abs(crab - avg)); i++)
                {
                    subtotal += i;
                }

                total += subtotal;
            }

            return total;
        }

        public override ValueTask<string> Solve_1() => new(CheapestFuel(_input).ToString());

        public override ValueTask<string> Solve_2() => new(CheapestFuelAvg(_input).ToString());
    }
}
