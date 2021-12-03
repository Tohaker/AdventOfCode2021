using AoCHelper;

namespace AdventOfCode
{
    public class Day_03 : BaseDay
    {
        private readonly string[] _input;

        public Day_03()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        public (int, int) CalculateGammaAndEpsilonRate(string[] input)
        {
            string gamma = "";
            string epsilon = "";

            int codeLength = input[0].Length;

            for (int i = 0; i < codeLength; i++)
            {
                var transposed = "";

                foreach (var code in input)
                {
                    transposed += code[i];
                }

                int oneCount = transposed.Count(f => f == '1');
                int transposedLength = transposed.Length;

                if (oneCount > transposedLength / 2)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }

            return (Convert.ToInt32(gamma, 2), Convert.ToInt32(epsilon, 2));
        }

        private int CalculateLifeSupportRating(string[] originalInput, Func<int, int, bool> predicate)
        {
            int codeLength = originalInput[0].Length;
            string[] currentInput = originalInput;

            // Go throw each digit in the code
            for (int i = 0; i < codeLength; i++)
            {
                // Find most common digit
                int oneCount = 0;
                int zeroCount = 0;

                if (currentInput.Length == 1)
                {
                    break;
                }

                foreach (var code in currentInput)
                {
                    if (code[i] == '1') oneCount++;
                    else zeroCount++;
                }

                currentInput = predicate(oneCount, zeroCount) ? currentInput.Where(l => l[i] == '1').ToArray() : currentInput.Where(l => l[i] == '0').ToArray();
            }

            return Convert.ToInt32(currentInput[0], 2);
        }

        public (int, int) CalculateOxygenAndCO2Rating(string[] input)
        {
            int oxygenRating = CalculateLifeSupportRating(input, (oneCount, zeroCount) => oneCount >= zeroCount);
            int co2Rating = CalculateLifeSupportRating(input, (oneCount, zeroCount) => oneCount < zeroCount);

            return (oxygenRating, co2Rating);
        }

        public override ValueTask<string> Solve_1()
        {
            var rates = CalculateGammaAndEpsilonRate(_input);
            var result = rates.Item1 * rates.Item2;

            return new(result.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var rates = CalculateOxygenAndCO2Rating(_input);
            var result = rates.Item1 * rates.Item2;

            return new(result.ToString());
        }
    }
}
