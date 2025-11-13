using AdventOfCode.Utils;

namespace AdventOfCode2021
{
    internal class Day14 : Day
    {

        public Day14() : base(14)
        { }

        public override string ProblemOne()
        {
            return Solve(10);
        }

        public override string ProblemTwo()
        {
            return Solve(40);
        }



        public string Solve(int iterations)
        {
            Dictionary<string, long> polymers = new Dictionary<string, long>();
            Dictionary<string, char> rules = new Dictionary<string, char>();
            Dictionary<char, long> singleElements = new Dictionary<char, long>();


            string firstLine = lines.First();
            for (int i = 0; i < firstLine.Length - 1; i++)
            {
                var key = firstLine.Substring(i, 2);
                polymers.AddOrAppend(key, 1);
                singleElements.AddOrAppend(firstLine[i], 1);
            }
            singleElements.AddOrAppend(firstLine[firstLine.Length - 1], 1);

            for (int i = 2; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                var key = line.Substring(0, 2);
                rules.Add(key, line[line.Length - 1]);
            }

            for (int iteration = 0; iteration < iterations; iteration++)
            {
                Dictionary<string, long> newPolymers = new Dictionary<string, long>();
                foreach (var key in polymers.Keys)
                {
                    var amount = polymers[key];
                    var compositePart = rules[key];

                    singleElements.AddOrAppend(compositePart, amount);

                    string newKey1 = key[0].ToString() + compositePart;
                    var newKey2 = compositePart + key[1].ToString();

                    newPolymers.AddOrAppend(newKey1, amount);
                    newPolymers.AddOrAppend(newKey2, amount);
                }

                polymers = newPolymers;
            }

            long highest = 0;
            long lowest = long.MaxValue;

            foreach (var key in singleElements.Keys)
            {
                long amount = singleElements[key];
                if (amount > highest)
                    highest = amount;
                if (amount < lowest)
                    lowest = amount;
            }

            return (highest - lowest).ToString();
        }
    }
}

