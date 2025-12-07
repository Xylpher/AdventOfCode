using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day7 : Day
    {
        public Day7() : base(7)
        {
        }

        public override string ProblemOne()
        {
            long result = 0;

            HashSet<int> beamIndexes = new HashSet<int>();
            beamIndexes.Add(lines.First().IndexOf('S'));
            for (int i = 1; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                var nextBeamIndexes = new HashSet<int>();
                foreach (var beam in beamIndexes)
                {
                    if (line[beam] == '^')
                    {
                        nextBeamIndexes.Add(beam + 1);
                        nextBeamIndexes.Add(beam - 1);
                        result++;
                    }
                    else
                        nextBeamIndexes.Add(beam);
                }
                beamIndexes = nextBeamIndexes;
            }

            return result.ToString();
        }

        public override string ProblemTwo()
        {
            long result = 0;

            Dictionary<int, long> beamsAtLocation = new Dictionary<int, long>();
            beamsAtLocation.Add(lines.First().IndexOf('S'), 1);
            for (int i = 1; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                Dictionary<int, long> newBeamsAtLocation = new Dictionary<int, long>();
                foreach (var beam in beamsAtLocation)
                {
                    if (line[beam.Key] == '^')
                    {
                        newBeamsAtLocation.AddOrAppend(beam.Key + 1, beam.Value);
                        newBeamsAtLocation.AddOrAppend(beam.Key - 1, beam.Value);
                    }
                    else
                        newBeamsAtLocation.AddOrAppend(beam.Key, beam.Value);
                }
                beamsAtLocation = newBeamsAtLocation;
            }
            result = beamsAtLocation.Values.Sum();

            return result.ToString();
        }
    }
}

