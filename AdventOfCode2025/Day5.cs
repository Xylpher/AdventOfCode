using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day5 : Day
    {
        List<Tuple<long, long>> freshItemRanges = new List<Tuple<long, long>>();
        List<long> items = new List<long>();

        public Day5() : base(5)
        {
            bool freshRange = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    freshRange = false;
                    continue;
                }
                if (freshRange)
                {
                    var split = line.Split('-');
                    freshItemRanges.Add(Tuple.Create(Convert.ToInt64(split[0]), Convert.ToInt64(split[1])));
                }
                else
                    items.Add(Convert.ToInt64(line));
            }
        }

        public override string ProblemOne()
        {
            var result = 0;
            result = items.Where(x => freshItemRanges.Any(y => x >= y.Item1 && x <= y.Item2)).Count();
            return result.ToString();
        }
        public override string ProblemTwo()
        {
            bool merged = true;
            while (merged)
            {
                List<Tuple<long, long>> newRanges = new List<Tuple<long, long>>();
                merged = false;
                foreach (var entry in freshItemRanges)
                {
                    //new entry gets eclipsed by one already in the list
                    var tuple = newRanges.Where(x => entry.Item1 >= x.Item1 && entry.Item2 <= x.Item2).FirstOrDefault();
                    if (tuple != null)
                    {
                        continue;
                    }
                    //lower lower bound and lower higherbound but overlapping
                    tuple = newRanges.Where(x => entry.Item1 <= x.Item1 && entry.Item2 <= x.Item2 && entry.Item2 >= x.Item1).FirstOrDefault();
                    if (tuple != null)
                    {
                        newRanges.Remove(tuple);
                        newRanges.Add(Tuple.Create(entry.Item1, tuple.Item2));
                        merged = true;
                        continue;
                    }
                    //higher lower bound and higher higherbound but overlapping
                    tuple = newRanges.Where(x => entry.Item1 >= x.Item1 && entry.Item2 >= x.Item2 && entry.Item1 <= x.Item2).FirstOrDefault();
                    if (tuple != null)
                    {
                        newRanges.Remove(tuple);
                        newRanges.Add(Tuple.Create(tuple.Item1, entry.Item2));
                        merged = true;
                        continue;
                    }
                    //entries that are fully contained in the new entry 
                    var tuples = newRanges.Where(x => x.Item1 >= entry.Item1 && x.Item2 <= entry.Item2).ToList();
                    tuples.ForEach(x => newRanges.Remove(x));

                    newRanges.Add(entry);
                }
                freshItemRanges = newRanges;
            }
            long result = 0;
            freshItemRanges.ForEach(x => result += (x.Item2 - x.Item1 + 1));

            return result.ToString();
        }
    }
}

