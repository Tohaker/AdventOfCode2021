using AoCHelper;
using System.Numerics;

namespace AdventOfCode
{
    public class Day_11 : BaseDay
    {
        private readonly string[] _input;

        public Day_11()
        {
            _input = File.ReadAllText(InputFilePath).Split('\n');
        }

        private List<List<int>> GetEnergyLevels(string[] input)
        {
            List<List<int>> energyLevels = new List<List<int>>();

            foreach (var line in input)
            {
                energyLevels.Add(Array.ConvertAll(line.ToCharArray(), c => c - '0').ToList());
            }

            return energyLevels;
        }

        private void RaiseEnergyLevels(ref List<List<int>> octopi, int value)
        {
            for (int i = 0; i < octopi.Count(); i++)
            {
                var row = octopi[i];
                for (int j = 0; j < row.Count(); j++)
                {
                    octopi[i][j]++;
                }
            }
        }

        private int FlashOctopi(ref List<List<int>> octopi, int threshold)
        {
            int flashCount = 0;
            int prevFlashCount = -1;

            List<Vector2> alreadyFlashed = new List<Vector2>();

            var rowCount = octopi.Count() - 1;
            var rowLength = octopi[0].Count() - 1;

            while (flashCount != prevFlashCount)
            {
                prevFlashCount = flashCount;
                for (int i = 0; i <= rowCount; i++)
                {
                    var row = octopi[i];
                    for (int j = 0; j <= rowLength; j++)
                    {
                        if (row[j] > threshold)
                        {
                            // This octopus flashes (how to check if flashed only once?)
                            if (alreadyFlashed.Contains(new Vector2(j, i))) continue;

                            flashCount++;
                            alreadyFlashed.Add(new Vector2(j, i));

                            // Raise value of surrounding octopi
                            if (i == 0)
                            {
                                if (j == 0)
                                {
                                    octopi[i][j + 1]++;
                                    octopi[i + 1][j]++;
                                    octopi[i + 1][j + 1]++;
                                }
                                else if (j == rowLength)
                                {
                                    octopi[i][j - 1]++;
                                    octopi[i + 1][j]++;
                                    octopi[i + 1][j - 1]++;
                                }
                                else
                                {
                                    octopi[i][j + 1]++;
                                    octopi[i][j - 1]++;

                                    octopi[i + 1][j]++;
                                    octopi[i + 1][j + 1]++;
                                    octopi[i + 1][j - 1]++;
                                }
                            }
                            else if (i == rowCount)
                            {
                                if (j == 0)
                                {
                                    octopi[i][j + 1]++;
                                    octopi[i - 1][j]++;
                                    octopi[i - 1][j + 1]++;
                                }
                                else if (j == rowLength)
                                {
                                    octopi[i][j - 1]++;
                                    octopi[i - 1][j]++;
                                    octopi[i - 1][j - 1]++;
                                }
                                else
                                {
                                    octopi[i][j + 1]++;
                                    octopi[i][j - 1]++;

                                    octopi[i - 1][j]++;
                                    octopi[i - 1][j + 1]++;
                                    octopi[i - 1][j - 1]++;
                                }
                            }
                            else
                            {

                                octopi[i - 1][j]++;
                                octopi[i + 1][j]++;

                                if (j == 0)
                                {
                                    octopi[i][j + 1]++;
                                    octopi[i - 1][j + 1]++;
                                    octopi[i + 1][j + 1]++;
                                }
                                else if (j == rowLength)
                                {
                                    octopi[i][j - 1]++;
                                    octopi[i - 1][j - 1]++;
                                    octopi[i + 1][j - 1]++;
                                }
                                else
                                {
                                    octopi[i][j - 1]++;
                                    octopi[i - 1][j - 1]++;
                                    octopi[i + 1][j - 1]++;

                                    octopi[i][j + 1]++;
                                    octopi[i - 1][j + 1]++;
                                    octopi[i + 1][j + 1]++;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var octo in alreadyFlashed)
            {
                octopi[(int)octo.Y][(int)octo.X] = 0;
            }

            return flashCount;
        }

        private void DebugOctopi(ref List<List<int>> octopi)
        {
            string output = "";

            foreach (var row in octopi)
            {
                output += (String.Join(' ', Array.ConvertAll(row.ToArray(), i => i.ToString()))) + '\n';
            }

            Console.WriteLine(output);
        }

        private int SumAllEnergyLevels(ref List<List<int>> octopi)
        {
            int count = 0;

            foreach (var row in octopi)
            {
                count += row.Sum();
            }

            return count;
        }

        public int CountFlashes(string[] input, int steps)
        {
            int count = 0;

            var energyLevels = GetEnergyLevels(input);

            for (int i = 0; i < steps; i++)
            {
                // DebugOctopi(ref energyLevels);
                RaiseEnergyLevels(ref energyLevels, 1);
                count += FlashOctopi(ref energyLevels, 9);
            }

            return count;
        }

        public int FindSimultaneousFlashes(string[] input)
        {
            int i = 0;

            var energyLevels = GetEnergyLevels(input);

            while (SumAllEnergyLevels(ref energyLevels) != 0)
            {
                RaiseEnergyLevels(ref energyLevels, 1);
                FlashOctopi(ref energyLevels, 9);
                i++;
            }

            return i;
        }

        public override ValueTask<string> Solve_1() => new(CountFlashes(_input, 100).ToString());

        public override ValueTask<string> Solve_2() => new(FindSimultaneousFlashes(_input).ToString());
    }
}
