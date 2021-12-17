using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_17_Should
    {
        Day_17 day = new Day_17();
        string input = "target area: x=20..30, y=-10..-5";

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result = day.FindHighestY(input);

            Assert.Equal(45, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("17766", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("Solution 2", result);
        }
    }
}
