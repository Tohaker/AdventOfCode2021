using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_01_Should
    {
        Day_01 day = new Day_01();
        int[] input = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            Assert.Equal(7, day.CalculateDepthIncreases(input));
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            Assert.Equal(5, day.CalculateCumulativeDepthIncreases(input));
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("1288", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("1311", result);
        }
    }
}
