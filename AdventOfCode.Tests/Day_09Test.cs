using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_09_Should
    {
        Day_09 day = new Day_09();
        string[] input = new string[] {
            "2199943210",
            "3987894921",
            "9856789892",
            "8767896789",
            "9899965678",
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result = day.FindLowPoints(input);

            Assert.Equal(15, result);
        }

        public void Example2_ReturnsAnswer()
        {
            var result = day.FindBasins(input);

            Assert.Equal(1134, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("514", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("1103130", result);
        }
    }
}
