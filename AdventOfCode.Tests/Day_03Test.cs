using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_03_Should
    {
        Day_03 day = new Day_03();

        string[] input = new string[] {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result = day.CalculateGammaAndEpsilonRate(input);

            Assert.Equal(22, result.Item1);
            Assert.Equal(9, result.Item2);
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            var result = day.CalculateOxygenAndCO2Rating(input);

            Assert.Equal(23, result.Item1);
            Assert.Equal(10, result.Item2);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("738234", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("3969126", result);
        }
    }
}
