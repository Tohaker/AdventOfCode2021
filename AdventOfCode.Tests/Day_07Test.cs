using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_07_Should
    {
        Day_07 day = new Day_07();
        int[] input = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result = day.CheapestFuel(input);

            Assert.Equal(37, result);
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            var result = day.CheapestFuelAvg(input);

            Assert.Equal(168, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("341534", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("Solution 2", result);
        }
    }
}
