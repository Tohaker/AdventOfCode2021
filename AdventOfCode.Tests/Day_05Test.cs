using System.Numerics;
using Xunit;

namespace AdventOfCode.Tests
{
    public class OceanFloor_Should
    {
        [Fact]
        public void MapLine_PlotsCorrectly()
        {
            string[] input = new string[] {
                "0,9 -> 5,9", "6,4 -> 2,0"
            };

            OceanFloor floor = new OceanFloor(input, true);

            var floorMap = floor.ventMap;

            Assert.Equal(1, floorMap.TryGetValue(new Vector2(0, 9), out var value) ? value : 0);
            Assert.Equal(1, floorMap.TryGetValue(new Vector2(1, 9), out var value1) ? value1 : 0);
            Assert.Equal(1, floorMap.TryGetValue(new Vector2(2, 9), out var value2) ? value2 : 0);
            Assert.Equal(1, floorMap.TryGetValue(new Vector2(3, 9), out var value3) ? value3 : 0);
            Assert.Equal(1, floorMap.TryGetValue(new Vector2(4, 9), out var value4) ? value4 : 0);
            Assert.Equal(1, floorMap.TryGetValue(new Vector2(5, 9), out var value5) ? value5 : 0);

            Assert.Equal(0, floorMap.TryGetValue(new Vector2(6, 4), out var value6) ? value6 : 0);
        }
    }

    public class Day_05_Should
    {
        Day_05 day = new Day_05();
        string[] input = new string[] {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2",
        };

        [Fact]
        public void Example1_ReturnsAnswer()
        {
            OceanFloor floor = new OceanFloor(input, true);

            Assert.Equal(5, floor.CountOverlappingVents());
        }

        [Fact]
        public void Example2_ReturnsAnswer()
        {
            OceanFloor floor = new OceanFloor(input, false);

            Assert.Equal(12, floor.CountOverlappingVents());
        }

        [Fact]
        public void Solution1_ReturnsAnswer()
        {
            var result = day.Solve_1().ToString();

            Assert.Equal("5124", result);
        }

        [Fact]
        public void Solution2_ReturnsAnswer()
        {
            var result = day.Solve_2().ToString();

            Assert.Equal("19771", result);
        }
    }
}
