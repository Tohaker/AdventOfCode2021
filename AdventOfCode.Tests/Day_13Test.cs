using System.Numerics;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day_13_Should
    {
        Day_13 day = new Day_13();
        string[] input = new string[] {
            "6,10",
            "0,14",
            "9,10",
            "0,3",
            "10,4",
            "4,11",
            "6,0",
            "6,12",
            "4,1",
            "0,13",
            "10,12",
            "3,4",
            "3,0",
            "8,4",
            "1,10",
            "2,14",
            "8,10",
            "9,0",
            "",
            "fold along y=7",
            "fold along x=5",
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            var dots = day.FoldPaper(input, 1);

            Assert.Equal(17, dots.Count);
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            var output = day.PrintDots(day.FoldPaper(input));
            var expected = "#####\n#   #\n#   #\n#   #\n#####\n";

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("743", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();
            var expected =
@"###   ##  ###  #     ##  #  # #  # #   
#  # #  # #  # #    #  # # #  #  # #   
#  # #    #  # #    #  # ##   #### #   
###  #    ###  #    #### # #  #  # #   
# #  #  # #    #    #  # # #  #  # #   
#  #  ##  #    #### #  # #  # #  # ####
";

            Assert.Equal(expected, result);
        }
    }
}
