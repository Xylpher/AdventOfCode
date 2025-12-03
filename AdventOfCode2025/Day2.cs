using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day2 : Day
    {
        private IEnumerable<string> ranges;

        Dictionary<int, List<int>> divisors = new Dictionary<int, List<int>>();

        public Day2() : base(2)
        {
            ranges = lines.First().Split(',').ToList();
            for (int i = 1; i < 15; i++)
            {
                divisors.Add(i, new List<int>());
                for (int j = 1; j <= i / 2; j++)
                {
                    if (i % j == 0)
                        divisors[i].Add(j);
                }
            }
        }

        public override string ProblemOne()
        {
            return FindIdsSimple();
        }

        public override string ProblemTwo()
        {
            return FindIdsAdvanced();
        }

        private string FindIdsSimple()
        {
            long result = 0;
            foreach (var entry in ranges)
            {
                var split = entry.Split("-");
                var start = Convert.ToInt64(split[0]);
                var end = Convert.ToInt64(split[1]);

                for (long currentNumber = start; currentNumber <= end; currentNumber++)
                {
                    string stringNumber = currentNumber.ToString();
                    if (stringNumber.Length % 2 == 0)
                    {
                        int frontIndex = 0;
                        int backIndex = stringNumber.Length / 2;

                        bool valid = false;
                        while (backIndex < stringNumber.Length && !valid)
                        {
                            if (stringNumber[frontIndex] != stringNumber[backIndex])
                            {
                                valid = true;
                            }
                            backIndex++;
                            frontIndex++;
                        }
                        if (!valid)
                            result += currentNumber;
                    }
                }
            }
            return result.ToString();
        }

        private string FindIdsAdvanced()
        {
            long result = 0;
            foreach (var entry in ranges)
            {
                var split = entry.Split("-");
                var start = Convert.ToInt64(split[0]);
                var end = Convert.ToInt64(split[1]);

                for (long currentNumber = start; currentNumber <= end; currentNumber++)
                {
                    string stringNumber = currentNumber.ToString();
                    var divisorsForNumber = divisors[stringNumber.Length];
                    if (currentNumber == 1000)
                        ;

                    bool valid = true;
                    foreach (var div in divisorsForNumber)
                    {
                        if (valid)
                        {
                            var currentStartIndex = 0;
                            var validThisIteration = false;
                            var numberToFind = stringNumber.Substring(0, div);
                            currentStartIndex += div;
                            while (currentStartIndex <= stringNumber.Length - div && !validThisIteration)
                            {
                                var nextSubString = stringNumber.Substring(currentStartIndex, div);
                                if (numberToFind != nextSubString)
                                {
                                    validThisIteration = true;
                                }
                                currentStartIndex += div;
                            }

                            if (!validThisIteration)
                                valid = false;
                        }
                    }

                    if (!valid)
                        result += currentNumber;
                }
            }
            return result.ToString();
        }

    }
}

