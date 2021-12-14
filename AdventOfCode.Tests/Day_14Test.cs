using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_14_Should
    {
        Day_14 day = new Day_14();
        string[] input = new string[] {
            "NNCB",
            "",
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C",
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result = day.FindElementQuantities(input, 10);

            Assert.Equal(1588, result);
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            var result = day.FindElementQuantities(input, 40);

            Assert.Equal(2188189693529, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("3411", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("7477815755570", result);
        }
    }
}
