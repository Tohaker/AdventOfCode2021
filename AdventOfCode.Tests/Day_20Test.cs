using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_20_Should
    {
        Day_20 day = new Day_20();

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("Solution 1", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("Solution 2", result);
        }
    }
}
