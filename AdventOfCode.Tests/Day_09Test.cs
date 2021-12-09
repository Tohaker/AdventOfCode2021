using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_09_Should
    {
        Day_09 day = new Day_09();

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
