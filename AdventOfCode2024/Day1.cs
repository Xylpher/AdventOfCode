using AdventOfCode.Utils;

namespace AdventOfCode2024
{
    internal class Day1 : Day
    {

        private List<int> left = new List<int>();
        private List<int> right = new List<int>();

        public Day1() : base(1)
        {
        }

        public override string ProblemOne()
        {
            foreach (var line in lines)
            {
                var split = line.Split(' ');
                left.Add(int.Parse(split.First()));
                right.Add(int.Parse(split.Last()));
            }

            left.Sort();
            right.Sort();

            var score = 0;
            if (left.Count == right.Count)
            {
                for (int i = 0; i < left.Count; i++)
                {
                    var dif = Math.Abs(left[i] - right[i]);
                    score += dif;
                }
            }

            return score.ToString();
        }

        public override string ProblemTwo()
        {
            int score = 0;
            foreach (var element in left)
            {
                var occurenceCount = right.Count(x => x == element);
                if (occurenceCount > 0)
                {
                    var addScore = element * occurenceCount;
                    score += addScore;
                }
            }
            return score.ToString();
        }
    }
}
