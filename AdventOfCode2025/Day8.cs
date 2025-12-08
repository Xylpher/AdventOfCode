using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day8 : Day
    {
        List<Tuple<int, int, int>> boxes = new List<Tuple<int, int, int>>();
        public Day8() : base(8)
        {
            foreach (var line in lines)
            {
                var split = line.Split(',');
                boxes.Add(Tuple.Create(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])));
            }
            DistanceHelper.Init(boxes);
        }

        public override string ProblemOne()
        {
            long result = 0;
            List<HashSet<Tuple<int, int, int>>> circuits = new List<HashSet<Tuple<int, int, int>>>();
            var first1000keys = DistanceHelper.FoundDistancesInverted.Keys.ToList();
            first1000keys.Sort();
            first1000keys = first1000keys.Take(1000).ToList();
            foreach (var key in first1000keys)
            {
                var points = DistanceHelper.FoundDistancesInverted[key];
                var inUseCircuits = circuits.Where(x => x.Contains(points.Item1) || x.Contains(points.Item2));

                if (!inUseCircuits.Any())
                {
                    circuits.Add(new HashSet<Tuple<int, int, int>>() { points.Item1, points.Item2 });
                }
                if (inUseCircuits.Count() == 1)
                {
                    inUseCircuits.First().Add(points.Item1);
                    inUseCircuits.First().Add(points.Item2);
                }
                else
                {
                    var firstCircuit = inUseCircuits.First();
                    var secondCircuit = inUseCircuits.Last();
                    foreach (var point in firstCircuit)
                        secondCircuit.Add(point);

                    circuits.Remove(firstCircuit);
                }
            }

            var biggestCircuits = circuits.OrderByDescending(x => x.Count).Take(3);
            result = 1;
            foreach (var circuit in biggestCircuits)
                result *= circuit.Count;

            return result.ToString();
        }

        public override string ProblemTwo()
        {
            long result = 0;

            int boxesTotal = boxes.Count();

            List<HashSet<Tuple<int, int, int>>> circuits = new List<HashSet<Tuple<int, int, int>>>();
            var keys = DistanceHelper.FoundDistancesInverted.Keys.ToList();
            keys.Sort();
            foreach (var key in keys)
            {
                var points = DistanceHelper.FoundDistancesInverted[key];
                var inUseCircuits = circuits.Where(x => x.Contains(points.Item1) || x.Contains(points.Item2));

                if (!inUseCircuits.Any())
                {
                    circuits.Add(new HashSet<Tuple<int, int, int>>() { points.Item1, points.Item2 });
                }
                if (inUseCircuits.Count() == 1)
                {
                    inUseCircuits.First().Add(points.Item1);
                    inUseCircuits.First().Add(points.Item2);
                }
                else
                {
                    var firstCircuit = inUseCircuits.First();
                    var secondCircuit = inUseCircuits.Last();
                    foreach (var point in firstCircuit)
                        secondCircuit.Add(point);

                    circuits.Remove(firstCircuit);
                }

                if (circuits.Count() == 1 && circuits.First().Count() == boxesTotal)
                {
                    result = points.Item1.Item1 * points.Item2.Item1;
                    break;
                }
            }
            return result.ToString();
        }
    }

    internal static class DistanceHelper
    {
        public static Dictionary<Tuple<Tuple<int, int, int>, Tuple<int, int, int>>, double> FoundDistances = new Dictionary<Tuple<Tuple<int, int, int>, Tuple<int, int, int>>, double>();
        public static Dictionary<double, Tuple<Tuple<int, int, int>, Tuple<int, int, int>>> FoundDistancesInverted = new Dictionary<double, Tuple<Tuple<int, int, int>, Tuple<int, int, int>>>();


        public static double GetDistance(Tuple<int, int, int> p1, Tuple<int, int, int> p2)
        {
            var distance = Math.Sqrt(Math.Pow(p1.Item1 - p2.Item1, 2) + Math.Pow(p1.Item2 - p2.Item2, 2) + Math.Pow(p1.Item3 - p2.Item3, 2));
            var points = Tuple.Create(p1, p2);
            FoundDistances.Add(points, distance);
            FoundDistancesInverted.Add(distance, points);

            return distance;
        }

        public static void Init(List<Tuple<int, int, int>> boxes)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = i + 1; j < boxes.Count; j++)
                {
                    GetDistance(boxes[i], boxes[j]);
                }
            }
        }
    }
}

