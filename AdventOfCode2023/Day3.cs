using AdventOfCode.Utils;

namespace AdventOfCode2023
{
    internal class Day3 : Day
    {
        private List<PartNumber> partNumbers = new List<PartNumber>();

        public Day3() : base(3)
        {
        }

        public override string ProblemOne()
        {
            var score = 0;

            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                var newPartnumber = new PartNumber() { Line = i };

                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];
                    if (char.IsDigit(c))
                    {
                        newPartnumber.ValueAsString += c;
                        newPartnumber.Index.Add(j);
                    }
                    else if (newPartnumber.Index.Any())
                    {
                        partNumbers.Add(newPartnumber);
                        newPartnumber = new PartNumber() { Line = i };
                    }
                }

                if (newPartnumber.Index.Any())
                {
                    partNumbers.Add(newPartnumber);
                }
            }

            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];

                    if (c != '.' && !char.IsDigit(c))
                    {
                        List<int> possibleLines = new List<int>() { i - 1, i, i + 1 };
                        List<int> possibleIndex = new List<int>() { j - 1, j, j + 1 };

                        partNumbers.Where(x => possibleLines.Contains(x.Line) && possibleIndex.Any(y => x.Index.Contains(y)))
                            .ToList().ForEach(x => x.Active = true);
                    }
                }
            }
            partNumbers.Where(x => x.Active).ToList().ForEach(x => score += x.Value);

            return score.ToString();
        }

        public override string ProblemTwo()
        {
            var score = 0;

            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];

                    if (c == '*')
                    {
                        List<int> possibleLines = new List<int>() { i - 1, i, i + 1 };
                        List<int> possibleIndex = new List<int>() { j - 1, j, j + 1 };

                        var surroundingNumbers = partNumbers.Where(x => possibleLines.Contains(x.Line) && possibleIndex.Any(y => x.Index.Contains(y)));
                        if (surroundingNumbers.Count() == 2)
                        {
                            var gearscore = surroundingNumbers.First().Value * surroundingNumbers.Last().Value;
                            score += gearscore;
                        }
                    }
                }
            }
            return score.ToString();
        }
    }


    internal class PartNumber
    {
        public int Line { get; set; } = -1;
        public List<int> Index { get; } = new List<int>();
        public string ValueAsString { get; set; } = "";
        public int Value { get => int.Parse(ValueAsString); }
        public bool Active { get; set; } = false;
    }
}
