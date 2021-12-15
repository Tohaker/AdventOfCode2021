using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_15_Should
    {
        Day_15 day = new Day_15();
        string[] input = new string[] {
            "1163751742",
            "1381373672",
            "2136511328",
            "3694931569",
            "7463417111",
            "1319128137",
            "1359912421",
            "3125421639",
            "1293138521",
            "2311944581",
        };

        string[] input2 = new string[] {
            "19999",
            "19111",
            "11191"
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result = day.FindLowestRiskPath(input);

            Assert.Equal(40, result);
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            var result = day.FindLowestRiskPath(day.ExpandMap(input));

            Assert.Equal(315, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("447", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("2825", result);
        }
    }
}
