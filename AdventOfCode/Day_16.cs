using AoCHelper;

namespace AdventOfCode
{
    public enum Represents
    {
        LITERAL,
        OPERATOR
    }

    public class Packet
    {
        public int version { get; }
        public int typeID { get; }
        public string rawData { get; }
        public long value { get; set; }
        public Represents represents { get; }
        public List<Packet> subpackets { get; }

        public Packet(string bits)
        {
            // Find version and type
            version = Convert.ToInt32(bits.Substring(0, 3), 2);
            typeID = Convert.ToInt32(bits.Substring(3, 3), 2);

            rawData = bits.Substring(6);
            value = 0;
            represents = typeID == 4 ? Represents.LITERAL : Represents.OPERATOR;
            subpackets = new();
        }

        public int ParseData()
        {
            if (this.represents == Represents.LITERAL)
            {
                List<string> chunks = new();
                bool lastChunk = false;

                // Read each 5 bit chunk
                int i = 0;
                while (!lastChunk)
                {
                    if (rawData[i] == '0') lastChunk = true;

                    chunks.Add(rawData.Substring(i + 1, 4));
                    i += 5;
                }

                var binary = String.Join("", chunks);
                this.value = Convert.ToInt64(binary, 2);

                // Return total length processed
                // Extra 6 is for Version and TypeID on literal
                return chunks.Count * 5 + 6;
            }
            else
            {
                var lengthTypeID = rawData[0];
                var prependedBits = 7;

                if (lengthTypeID == '0')
                {
                    // Next 15 bits represents the number of bits in all the subpackets
                    var bitsToCount = 15;
                    var length = Convert.ToInt32(rawData.Substring(1, bitsToCount), 2);

                    var remainingData = rawData.Substring(bitsToCount + 1, length);
                    var processedBits = 0;

                    while (processedBits < length)
                    {
                        var currentPacket = new Packet(remainingData);
                        var bits = currentPacket.ParseData();
                        subpackets.Add(currentPacket);

                        processedBits += bits;
                        remainingData = remainingData.Substring(bits);
                    }

                    // Packet length is 7 (VVVTTTI) + 15 bits to calc length + length to process 
                    return prependedBits + bitsToCount + length;
                }
                else
                {
                    // Next 11 bits represents the number of subpackets
                    var bitsToCount = 11;
                    var length = Convert.ToInt32(rawData.Substring(1, bitsToCount), 2);

                    var remainingData = rawData.Substring(bitsToCount + 1);
                    var processedBits = 0;

                    while (subpackets.Count < length)
                    {
                        var currentPacket = new Packet(remainingData);
                        var bits = currentPacket.ParseData();
                        subpackets.Add(currentPacket);

                        processedBits += bits;
                        remainingData = remainingData.Substring(bits);
                    }

                    // Packet length is 7 (VVVTTTI) + 11 bits to calc length + bits that were processed 
                    return prependedBits + bitsToCount + processedBits;
                }
            }
        }

    }

    public class Day_16 : BaseDay
    {
        private readonly string _input;

        public Day_16()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        private int RecursePacketVersion(Packet packet, int count)
        {
            count += packet.version;

            if (packet.subpackets.Count > 0)
            {
                foreach (var p in packet.subpackets)
                {
                    count = RecursePacketVersion(p, count);
                }
            }

            return count;
        }

        private long RecursePacketCalculation(Packet packet, long total)
        {
            var id = packet.typeID;
            long value = 0;
            long v1 = 0;
            long v2 = 0;
            List<long> values = new();

            if (id == 2 || id == 3)
            {
                foreach (var p in packet.subpackets)
                {
                    if (p.represents == Represents.LITERAL)
                        values.Add(p.value);
                    else
                        values.Add(RecursePacketCalculation(p, value));
                }
            }

            if (id >= 5)
            {
                v1 = packet.subpackets[0].represents == Represents.LITERAL ? packet.subpackets[0].value : RecursePacketCalculation(packet.subpackets[0], 0);
                v2 = packet.subpackets[1].represents == Represents.LITERAL ? packet.subpackets[1].value : RecursePacketCalculation(packet.subpackets[1], 0);

            }

            switch (id)
            {
                case 0:
                    foreach (var p in packet.subpackets)
                    {
                        value = p.represents == Represents.LITERAL ?
                            value + p.value
                            : value + RecursePacketCalculation(p, value);
                    }
                    return value;
                case 1:
                    value = 1;
                    foreach (var p in packet.subpackets)
                    {
                        value = p.represents == Represents.LITERAL ?
                            value * p.value
                            : value * RecursePacketCalculation(p, value);
                    }
                    return value;
                case 2:
                    return values.Min();
                case 3:
                    return values.Max();
                case 5:
                    return v1 > v2 ? 1 : 0;
                case 6:
                    return v1 < v2 ? 1 : 0;
                case 7:
                    return v1 == v2 ? 1 : 0;
                default:
                    return value;
            }
        }

        public int SumVersionNumbers(string input)
        {
            // Convert Hex to Binary
            var bits = String.Join(String.Empty, input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            Packet packet = new(bits);
            packet.ParseData();

            return RecursePacketVersion(packet, 0);
        }

        public long RunCalculations(string input)
        {
            // Convert Hex to Binary
            var bits = String.Join(String.Empty, input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            Packet packet = new(bits);
            packet.ParseData();

            return RecursePacketCalculation(packet, 0);
        }

        public override ValueTask<string> Solve_1() => new(SumVersionNumbers(_input).ToString());

        public override ValueTask<string> Solve_2() => new(RunCalculations(_input).ToString());
    }
}
