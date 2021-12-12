using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_12_Should
    {
        Day_12 day = new Day_12();

        static string[] input1 = new string[] {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end",
        };
        static string[] input2 = new string[] {
            "dc-end",
            "HN-start",
            "start-kj",
            "dc-start",
            "dc-HN",
            "LN-dc",
            "HN-end",
            "kj-sa",
            "kj-HN",
            "kj-dc",
        };
        static string[] input3 = new string[] {
            "fs-end",
            "he-DX",
            "fs-he",
            "start-DX",
            "pj-DX",
            "end-zg",
            "zg-sl",
            "zg-pj",
            "pj-he",
            "RW-he",
            "fs-DX",
            "pj-RW",
            "zg-RW",
            "start-pj",
            "he-WI",
            "zg-he",
            "pj-fs",
            "start-RW",
        };

        string[][] inputs = new string[][] { input1, input2, input3 };

        [Theory]
        [InlineData(0, 10)]
        [InlineData(1, 19)]
        [InlineData(2, 226)]
        public void Example1_ReturnsAnswer(int inputIdx, int expected)
        {
            var input = inputs[inputIdx];

            var result = day.FindAllPaths(input, false).Count;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 36)]
        [InlineData(1, 103)]
        [InlineData(2, 3509)]
        public void Example2_ReturnsAnswer(int inputIdx, int expected)
        {
            var input = inputs[inputIdx];

            var result = day.FindAllPaths(input, true).Count;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("3679", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("107395", result);
        }
    }
}
