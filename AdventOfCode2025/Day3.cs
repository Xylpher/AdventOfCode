using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day3 : Day
    {

        public Day3() : base(3)
        {
        }

        public override string ProblemOne()
        {
            var totalJoltage = 0;
            foreach (var line in lines)
            {
                int first = 0;
                int last = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    int number = Convert.ToInt32(line[i].ToString());
                    if (number > first && i < line.Length - 1)
                    {
                        first = number;
                        last = 0;
                    }
                    else if (number > last)
                        last = number;
                }
                var packageJoltage = first * 10 + last;
                totalJoltage += packageJoltage;
            }

            return totalJoltage.ToString();
        }

        public override string ProblemTwo()
        {

            long totalJoltage = 0;

            foreach (var line in lines)
            {
                string joltage = "";
                int startIndex = 0;
                for (int i = 0; i < 12; i++)
                {
                    var currentBox = line.Substring(startIndex, line.Length - startIndex - (11 - i));
                    var highest = currentBox.Max().ToString();
                    var index = currentBox.IndexOf(highest);
                    startIndex += index + 1;
                    joltage += highest;
                }
                totalJoltage += Convert.ToInt64(joltage);
            }

            return totalJoltage.ToString();
        }

    }
}

