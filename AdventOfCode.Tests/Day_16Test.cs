using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_16_Should
    {
        Day_16 day = new Day_16();

        [Theory]
        [InlineData("8A004A801A8002F478", 16)]
        [InlineData("620080001611562C8802118E34", 12)]
        [InlineData("C0015000016115A2E0802F182340", 23)]
        [InlineData("A0016C880162017C3686B18A3D4780", 31)]
        public void Example1_ReturnsAnswer(string input, int expected)
        {
            var result = day.SumVersionNumbers(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("883", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("Solution 2", result);
        }
    }
}
