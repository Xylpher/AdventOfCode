using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day1 : Day
    {

        public Day1() : base(1)
        { }

        public override string ProblemOne()
        {
            return RotateSimple();
        }

        public override string ProblemTwo()
        {
            return RotateAdvanced();
        }

        private string RotateSimple()
        {
            int position = 50;
            var result = 0;
            foreach (var line in lines)
            {
                char rotation = line[0];
                var amount = Convert.ToInt32(line.Substring(1));
                if (rotation == 'R')
                    position = (position + amount) % 100;
                else
                    position = (position - amount) % 100;
                if (position == 0)
                    result++;
            }
            return result.ToString();
        }

        private string RotateAdvanced()
        {
            bool onZeroLast = false;
            int position = 50;
            var result = 0;
            foreach (var line in lines)
            {
                char rotation = line[0];
                var amount = Convert.ToInt32(line.Substring(1));
                if (rotation == 'R')
                    position = position + amount;
                else
                    position = position - amount;

                if (position >= 100)
                {
                    result += Math.DivRem(position, 100, out position);
                }
                else if (position < 0)
                {
                    result += Math.Abs(Math.DivRem(position - 100, 100, out position));
                    if (onZeroLast)
                        result--;
                    var newPos = position % 100;

                    Math.DivRem(position + 100, 100, out position);
                }
                else if (position == 0)
                {
                    result++;
                }

                if (position == 0)
                    onZeroLast = true;
                else
                    onZeroLast = false;

            }
            return result.ToString();
        }
    }
}

