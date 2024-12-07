using AdventOfCode.Utils;

namespace AdventOfCode2024
{
    internal class Day5 : Day
    {
        int lineLenght;

        public Day5() : base(5)
        {
            lineLenght = lines.First().Length;
        }

        public override string ProblemOne()
        {
            var score = 0;

            List<Tuple<string, string>> pageRule = new List<Tuple<string, string>>();
            int lineIndex = 0;
            foreach (var line in lines)
            {
                lineIndex++;
                if (string.IsNullOrEmpty(line))
                    break;
                var split = line.Split('|');

                pageRule.Add(Tuple.Create(split[0], split[1]));
            }

            for (int i = lineIndex; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);

                bool viable = true;
                var lineSplit = line.Split(",").ToList();

                foreach (Tuple<string, string> rule in pageRule)
                {
                    int i1Index = lineSplit.IndexOf(rule.Item1);
                    int i2Index = lineSplit.IndexOf(rule.Item2);
                    if (i1Index >= 0 && i2Index >= 0 && i1Index >= i2Index)
                    {
                        viable = false;
                        break;
                    }
                }
                if (viable)
                {
                    var split = line.Split(',');
                    var middlePage = split[(split.Count() - 1) / 2];
                    var pageScore = int.Parse(middlePage);
                    score += pageScore;
                }
            }


            return score.ToString();
        }

        public override string ProblemTwo()
        {
            var score = 0;

            List<Tuple<string, string>> pageRule = new List<Tuple<string, string>>();
            int lineIndex = 0;
            foreach (var line in lines)
            {
                lineIndex++;
                if (string.IsNullOrEmpty(line))
                    break;
                var split = line.Split('|');

                pageRule.Add(Tuple.Create(split[0], split[1]));
            }

            for (int i = lineIndex; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);

                var lineSplit = line.Split(",").ToList();
                score += RearrangeLine(lineSplit, pageRule, true);
            }


            return score.ToString();
        }


        private int RearrangeLine(List<string> line, IEnumerable<Tuple<string, string>> rules, bool firstIteration)
        {
            var score = 0;

            var viable = true;
            foreach (var rule in rules)
            {
                int i1Index = line.IndexOf(rule.Item1);
                int i2Index = line.IndexOf(rule.Item2);
                if (i1Index >= 0 && i2Index >= 0 && i1Index >= i2Index)
                {
                    viable = false;
                    string temp = line[i1Index];
                    line[i1Index] = line[i2Index];
                    line[i2Index] = temp;
                    break;
                }
            }
            if (!viable)
                score = RearrangeLine((List<string>)line, rules, false);
            else if (!firstIteration)
            {
                var middlePage = line[(line.Count() - 1) / 2];
                var pageScore = int.Parse(middlePage);
                score += pageScore;
            }
            return score;
        }

    }
}
