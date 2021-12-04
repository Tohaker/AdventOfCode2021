using Xunit;

namespace AdventOfCode.Tests
{
    public class BingoCard_Should
    {
        string[] cardInput = new string[] {
            "22 13 17 11  0",
            "8  2 23  4 24",
            "21  9 14 16  7",
            "6 10  3 18  5",
            "1 12 20 15 19"
        };

        [Fact]
        public void MarkNumber_UpdatesCard()
        {
            BingoCard card = new BingoCard(cardInput);
            card.MarkNumber(10);

            Assert.Equal(10, card.card[3][1]);
            Assert.True(card.marked[3][1]);
        }

        [Theory]
        [InlineData(17, 23, 14, 3, 20)]
        [InlineData(1, 12, 20, 15, 19)]
        public void CheckLines_IsComplete_ReturnsLine(params int[] lineToCheck)
        {
            BingoCard card = new BingoCard(cardInput);

            foreach (var value in lineToCheck)
            {
                card.MarkNumber(value);
            }

            Assert.Equal(5, card.CheckLines().Length);
        }

        [Theory]
        [InlineData(17, 23, 14, 3, 8)]
        [InlineData(1, 12, 15, 19, 24)]
        public void CheckLines_IsNotComplete_ReturnsEmpty(params int[] lineToCheck)
        {
            BingoCard card = new BingoCard(cardInput);

            foreach (var value in lineToCheck)
            {
                card.MarkNumber(value);
            }

            Assert.Empty(card.CheckLines());
        }

        [Fact]
        public void UnmarkedNumbers_ReturnsAnswer()
        {
            BingoCard card = new BingoCard(cardInput);

            int[] marked = new int[] {
                22, 4, 9, 18, 5, 1, 20
            };

            foreach (var value in marked)
            {
                card.MarkNumber(value);
            }

            Assert.Equal(221, card.UnmarkedNumbers());
        }
    }

    public class Day_04_Should
    {
        Day_04 day = new Day_04();

        string[] input = new string[] {
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "22 13 17 11  0",
            " 8  2 23  4 24",
            "21  9 14 16  7",
            " 6 10  3 18  5",
            " 1 12 20 15 19",
            " 3 15  0  2 22",
            " 9 18 13 17  5",
            "19  8  7 25 23",
            "20 11 10 24  4",
            "14 21 16 12  6",
            "14 21 17 24  4",
            "10 16 15  9 19",
            "18  8 23 26 20",
            "22 11 13  6  5",
            " 2  0 12  3  7"
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            int result = day.PlayBingo(input);

            Assert.Equal(4512, result);
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            int result = day.PlayUntilLastBingoCard(input);

            Assert.Equal(1924, result);
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("44088", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("23670", result);
        }
    }
}
