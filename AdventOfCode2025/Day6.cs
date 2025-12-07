using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day6 : Day
    {
        public Day6() : base(6)
        {
        }

        public override string ProblemOne()
        {
            List<IEnumerable<string>> splits = new List<IEnumerable<string>>();
            foreach (var line in lines)
            {
                var split = line.Split(' ').ToList();
                split.RemoveAll(x => String.IsNullOrWhiteSpace(x));
                splits.Add(split);
            }

            long result = 0;
            for (int i = 0; i < splits.First().Count(); i++)
            {
                var op = splits.Last().ElementAt(i);

                long mathResult = Convert.ToInt64(splits.First().ElementAt(i));
                for (int j = 1; j < splits.Count() - 1; j++)
                {
                    switch (op)
                    {
                        case "*":
                            mathResult *= Convert.ToInt32(splits.ElementAt(j).ElementAt(i));
                            break;
                        case "+":
                            mathResult += Convert.ToInt64(splits.ElementAt(j).ElementAt(i));
                            break;
                    }
                }
                result += mathResult;
            }
            return result.ToString();
        }

        public override string ProblemTwo()
        {
            long result = 0;

            var lineLength = lines.First().Length;
            var op = ' ';
            List<string> numbers = new List<string>();

            for (int i = lineLength - 1; i >= 0; i--)
            {
                string nextNumber = "";
                for (int j = 0; j < lines.Count() - 1; j++)
                {
                    nextNumber += lines.ElementAt(j).ElementAt(i);
                }
                numbers.Add(nextNumber);
                try
                {
                    op = lines.Last().ElementAt(i);
                }
                catch (Exception ex) { }

                if (op != ' ')
                {
                    numbers.RemoveAll(x => String.IsNullOrWhiteSpace(x));

                    long mathResult = Convert.ToInt32(numbers[0]);
                    for (int z = 1; z < numbers.Count(); z++)
                    {
                        switch (op)
                        {
                            case '*':
                                mathResult *= Convert.ToInt32(numbers[z]);
                                break;
                            case '+':
                                mathResult += Convert.ToInt32(numbers[z]);
                                break;
                        }
                    }
                    numbers.Clear();
                    op = ' ';
                    result += mathResult;
                }
            }
            return result.ToString();
        }
    }
}

