using AdventOfCode.Utils;

namespace AdventOfCode2024
{
    internal class Day7 : Day
    {

        public Day7() : base(7)
        {
        }

        public override string ProblemOne()
        {
            long score = 0;
            foreach (var line in lines)
            {
                List<int> values = new List<int>();
                var split = line.Split(':');
                long expectedResult = long.Parse(split.First());
                string[] rightSide = split.Last().Split(' ');
                foreach (var item in rightSide)
                {
                    if (int.TryParse(item, out int asInt))
                        values.Add(asInt);
                }

                bool possible = false;

                possible = Check(values, 1, '+', values.First(), expectedResult)
                    || Check(values, 1, '*', values.First(), expectedResult);

                if (possible)
                    score += expectedResult;
            }
            return score.ToString();
        }
        public override string ProblemTwo()
        {
            long score = 0;
            foreach (var line in lines)
            {
                List<int> values = new List<int>();
                var split = line.Split(':');
                long expectedResult = long.Parse(split.First());
                string[] rightSide = split.Last().Split(' ');
                foreach (var item in rightSide)
                {
                    if (int.TryParse(item, out int asInt))
                        values.Add(asInt);
                }

                bool possible = false;

                possible = Check(values, 1, '+', values.First(), expectedResult, true)
                    || Check(values, 1, '*', values.First(), expectedResult, true)
                    || Check(values, 1, '|', values.First(), expectedResult, true);

                if (possible)
                    score += expectedResult;
            }
            return score.ToString();
        }

        private bool Check(IEnumerable<int> values, int currentPos, char nextOperator, long currentValue, long expectedResult, bool twoStar = false)
        {
            bool possible = false;
            if (nextOperator == '+')
            {
                currentValue += values.ElementAt(currentPos);
            }
            else if (nextOperator == '*')
            {
                currentValue *= values.ElementAt(currentPos);
            }
            else if (nextOperator == '|')
            {
                string combinedValue = currentValue.ToString() + values.ElementAt(currentPos).ToString();
                currentValue = long.Parse(combinedValue);
            }

            if (currentValue > expectedResult)
                return false;

            if (currentPos == values.Count() - 1)
            {
                if (currentValue == expectedResult)
                    possible = true;
            }
            else if (!twoStar)
            {
                possible = Check(values, currentPos + 1, '+', currentValue, expectedResult)
                    || Check(values, currentPos + 1, '*', currentValue, expectedResult);
            }
            else
            {
                possible = Check(values, currentPos + 1, '+', currentValue, expectedResult, twoStar)
                    || Check(values, currentPos + 1, '*', currentValue, expectedResult, twoStar)
                    || Check(values, currentPos + 1, '|', currentValue, expectedResult, twoStar);

            }
            return possible;
        }
    }
}
