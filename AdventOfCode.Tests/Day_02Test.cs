using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_02_Should
    {
        Day_02 day = new Day_02();
        string[] input = new string[] {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var position = day.MoveCartesian(input);
            Assert.Equal(150, position.Item1 * position.Item2);
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            var position = day.MoveWithAim(input);
            Assert.Equal(900, position.Item1 * position.Item2);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("2019945", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("1599311480", result);
        }
    }
}
