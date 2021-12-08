using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_08_Should
    {
        Day_08 day = new Day_08();
        string[] input = new string[] {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce",
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var result = day.CountUniqueDigits(input);

            Assert.Equal(26, result);
        }

        [Fact]
        public void DetermineSegmentCodes_ReturnsAnswer()
        {
            string[] _input = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab".Split();

            var result = day.DetermineSegmentCodes(_input);
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"cagedb", 0},
                {"ab", 1},
                {"gcdfa", 2},
                {"fbcad", 3},
                {"eafb", 4},
                {"cdfbe", 5},
                {"cdfgeb", 6},
                {"dab", 7},
                {"acedgfb", 8},
                {"cefabd", 9},
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            var result = day.CalculateTotalDisplay(input);

            Assert.Equal(61229, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("456", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("1091609", result);
        }
    }
}
