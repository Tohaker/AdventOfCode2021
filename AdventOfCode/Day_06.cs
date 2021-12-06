using AoCHelper;

namespace AdventOfCode
{
    public class Day_06 : BaseDay
    {
        private readonly int[] _input;

        public Day_06()
        {
            _input = Array.ConvertAll(File.ReadAllText(InputFilePath).Split(','), s => int.Parse(s));
        }

        public long SimulateFish(IEnumerable<int> initialFish, int days)
        {
            const int cycleLength = 7;
            const int delayPeriod = 2;

            // Create a "bucket" of fish cycle lengths
            var fish = new Dictionary<int, long>(Enumerable.Range(0, cycleLength).Select(i => new KeyValuePair<int, long>(i, 0)));

            // Group fish by their initial cycle length
            foreach (var day in initialFish.GroupBy(f => f))
            {
                fish[day.Key] = day.Count();
            }

            var queue = new Queue<long>(Enumerable.Range(0, delayPeriod).Select(_ => 0L));

            for (var i = 0; i < days; i++)
            {
                // Since it's a cycle, each day just progresses it by one
                var spawnersIndex = i % cycleLength;

                // Get the number of fish that will spawn and place them in the queue
                queue.Enqueue(fish[spawnersIndex]);

                // Remove the previous spawners from the queue and use them to create the new fish
                var juveniles = queue.Dequeue();

                // The new fish are added to the next cycle bucket (ignoring the 8th day)
                fish[(spawnersIndex + cycleLength) % cycleLength] += juveniles;
            }

            return fish.Sum(d => d.Value) + queue.Sum();
        }

        public override ValueTask<string> Solve_1() => new(SimulateFish(_input, 80).ToString());

        public override ValueTask<string> Solve_2() => new(SimulateFish(_input, 256).ToString());
    }
}
