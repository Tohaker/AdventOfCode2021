using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_10_Should
    {
        Day_10 day = new Day_10();
        string[] input = new string[] {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]",
        };

        [Fact]
        public void FindFirstIllegalCharacter_ReturnsAnswer()
        {
            var result = day.FindFirstIllegalCharacter(input[2]);

            Assert.Equal('}', result);
        }

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result = day.CountIllegalCharacters(input);

            Assert.Equal(26397, result);
        }

        [Fact]
        public void CompleteUnfinishedLine_ReturnsAnswer()
        {
            var result = day.CompleteUnfinishedLine(input[0]);
            var expected = new List<char>() { '}', '}', ']', ']', ')', '}', ')', ']' };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            var result = day.CountAutocompletedCharacters(input);

            Assert.Equal(288957, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("392043", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("1605968119", result);
        }
    }
}
