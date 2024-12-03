using AdventOfCode.Utils;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    internal class Day3 : Day
    {
        public Day3() : base(3)
        {
        }


        public override string ProblemOne()
        {
            var fullinput = string.Join("", lines);

            //Just Regex everything here
            var regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
            var match = regex.Match(fullinput);
            var result = 0;
            do
            {
                var substring = match.Value.Substring(4, match.Value.Length - 5);
                var split = substring.Split(',');
                var mul = int.Parse(split[0]) * int.Parse(split[1]);
                result += mul;
                match = match.NextMatch();
            } while (match.Success);

            return result.ToString();
        }

        public override string ProblemTwo()
        {
            var fullinput = string.Join("", lines);


            //Remove everything that is between a don't() and the next do()
            int nextIndexDont = fullinput.IndexOf("don't()");
            int nextIndexDo = fullinput.IndexOf("do()");
            do
            {
                //Remove from the d in don't to the ) in do()
                fullinput = fullinput.Remove(nextIndexDont, nextIndexDo - nextIndexDont + 4);

                nextIndexDo = fullinput.IndexOf("do()");
                nextIndexDont = fullinput.IndexOf("don't()");

                //if there is another do() before the next don't(), continue finding the next do() until the index of do() is higher than the don't() one
                while (nextIndexDont > nextIndexDo && nextIndexDo > 0)
                {
                    nextIndexDo = fullinput.IndexOf("do()", nextIndexDo + 1);
                }
            }
            while (nextIndexDont > 0 && nextIndexDo > 0);

            //if there is a don't() without a reactivating do(), delete everything after and including the don't()
            if (nextIndexDont > 0 && nextIndexDo < 0)
            {
                fullinput = fullinput.Remove(nextIndexDont);
            }


            //Same as Problem 1 from now on
            var regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");

            var match = regex.Match(fullinput);

            var result = 0;
            do
            {
                var substring = match.Value.Substring(4, match.Value.Length - 5);
                var split = substring.Split(',');
                var mul = int.Parse(split[0]) * int.Parse(split[1]);
                result += mul;
                match = match.NextMatch();
            } while (match.Success);

            return result.ToString();

        }
    }
}
