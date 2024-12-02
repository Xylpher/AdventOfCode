using AdventOfCode.Utils;

namespace AdventOfCode2024
{
    internal class Day2 : Day
    {
        public Day2() : base(2)
        {
        }

        public override string ProblemOne()
        {
            int correctData = 0;
            foreach (var report in lines)
            {
                var split = report.Split(' ');
                List<int> values = new List<int>();
                foreach (var item in split)
                {
                    values.Add(int.Parse(item));
                }

                if (CheckReport(values, true))
                    correctData++;
            }
            return correctData.ToString();
        }

        public override string ProblemTwo()
        {
            int correctData = 0;
            foreach (var report in lines)
            {
                var split = report.Split(' ');
                List<int> values = new List<int>();
                foreach (var item in split)
                {
                    values.Add(int.Parse(item));
                }
                if (CheckReport(values, false))
                    correctData++;
            }
            return correctData.ToString();
        }

        private bool CheckReport(List<int> values, bool dampenerActive)
        {
            var isDecreasing = values[0] > values[1];
            var difAbs = Math.Abs(values[0] - values[1]);
            if (difAbs < 1 || difAbs > 3)
            {
                if (dampenerActive)
                    return false;
                else
                {
                    var copy = new List<int>();
                    values.ForEach(x => copy.Add(x));
                    values.RemoveAt(0);
                    copy.RemoveAt(1);
                    return CheckReport(values, true) || CheckReport(copy, true);
                }
            }

            var dataViable = true;
            for (int i = 1; i < values.Count - 1; i++)
            {
                var dif = values[i] - values[i + 1];
                if ((isDecreasing && dif > 0) || (!isDecreasing && dif < 0))
                {
                    difAbs = Math.Abs(dif);
                    if (difAbs < 1 || difAbs > 3)
                    {
                        dataViable = false;
                    }
                }
                else
                {
                    dataViable = false;
                }

                if (!dataViable && !dampenerActive)
                {
                    var copyRemoveAfter = new List<int>();
                    var copyRemoveBefore = new List<int>();
                    values.ForEach(x =>
                    {
                        copyRemoveAfter.Add(x);
                        copyRemoveBefore.Add(x);
                    });
                    values.RemoveAt(i);
                    copyRemoveAfter.RemoveAt(i + 1);
                    copyRemoveBefore.RemoveAt(i - 1);
                    return CheckReport(values, true) || CheckReport(copyRemoveAfter, true) || CheckReport(copyRemoveBefore, true);
                }
            }

            return dataViable;
        }
    }
}
