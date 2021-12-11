using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_11_Should
    {
        Day_11 day = new Day_11();
        string[] input = new string[] {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526",
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result = day.CountFlashes(input, 100);

            Assert.Equal(1656, result);
        }

        public void Example2_ReturnsAnswer()
        {
            var result = day.FindSimultaneousFlashes(input);

            Assert.Equal(195, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("1723", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("327", result);
        }
    }
}
