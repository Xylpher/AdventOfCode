using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day4 : Day
    {
        Dictionary<int, int, char> values = new Dictionary<int, int, char>();


        public Day4() : base(4)
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '@')
                        values.Add(i, j, line[j]);
                }
            }
        }

        public override string ProblemOne()
        {
            int result = 0;
            foreach (var key in values.Keys)
            {
                if (CheckPosDic(key.Item1, key.Item2))
                    result++;
            }
            return result.ToString();
        }


        private bool CheckPosDic(int x, int y)
        {
            var adjacentRolls = 0;
            if (values.ContainsKey(x - 1, y - 1))
                adjacentRolls++;
            if (values.ContainsKey(x - 1, y))
                adjacentRolls++;
            if (values.ContainsKey(x - 1, y + 1))
                adjacentRolls++;
            if (values.ContainsKey(x, y - 1))
                adjacentRolls++;
            if (values.ContainsKey(x, y + 1))
                adjacentRolls++;
            if (values.ContainsKey(x + 1, y - 1))
                adjacentRolls++;
            if (values.ContainsKey(x + 1, y))
                adjacentRolls++;
            if (values.ContainsKey(x + 1, y + 1))
                adjacentRolls++;

            return adjacentRolls < 4;
        }

        public override string ProblemTwo()
        {
            int result = 0;
            List<Tuple<int, int>> changeValues = new List<Tuple<int, int>>();
            bool changeDone = true;
            while (changeDone)
            {
                foreach (var key in values.Keys)
                {
                    if (CheckPosDic(key.Item1, key.Item2))
                    {
                        result++;
                        changeValues.Add(key);
                    }
                }
                if (changeValues.Count > 0)
                {
                    foreach (var key in changeValues)
                    {
                        values.Remove(key);
                    }
                    changeValues.Clear();
                }
                else
                {
                    changeDone = false;
                }
            }

            return result.ToString();
        }

    }
}

