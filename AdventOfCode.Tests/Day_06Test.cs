using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_06_Should
    {
        Day_06 day = new Day_06();
        int[] input = new int[] { 3, 4, 3, 1, 2 };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result18 = day.SimulateFish(input, 18);
            var result80 = day.SimulateFish(input, 80);

            Assert.Equal(26, result18);
            Assert.Equal(5934, result80);
        }

        public void Example2_ReturnsAnswer()
        {
            var result = day.SimulateFish(input, 256);

            Assert.Equal(26984457539, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("363101", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("1644286074024", result);
        }
    }
}
