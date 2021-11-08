using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_01_Should
    {
        Day_01 day = new Day_01();

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1();

            Assert.Equal("Solution to Day 1, part 1", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2();

            Assert.Equal("Solution to Day 1, part 2", result);
        }
    }
}
