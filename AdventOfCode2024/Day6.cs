using AdventOfCode.Utils;

namespace AdventOfCode2024
{
    internal class Day6 : Day
    {

        public Day6() : base(6)
        {
        }

        public override string ProblemOne()
        {
            var visitedPointsCount = CheckPath(lines);
            return visitedPointsCount.ToString();
        }

        public override string ProblemTwo()
        {
            //Do not try at home, bruteforcing is not a good idea

            var score = 0;

            int maxI = lines.Count();
            int maxJ = lines.ElementAt(0).Length;

            for (int i = 0; i < maxI; i++)
            {
                for (int j = 0; j < maxJ; j++)
                {
                    int x = j;
                    int y = i;
                    var linesCopy = new List<string>();
                    foreach (var item in lines)
                    {
                        linesCopy.Add((string)item.Clone());
                    }

                    char c = linesCopy[i][j];
                    if (c == '#' || c == '^')
                        continue;

                    var oldLine = linesCopy[i];
                    var newLine = oldLine.Substring(0, x) + '#' + (j < maxJ ? oldLine.Substring(j + 1) : "");
                    linesCopy[i] = newLine;


                    var result = CheckPath(linesCopy, 1000);
                    if (result == -1)
                        score++;
                }
            }

            return score.ToString();
        }


        private int CheckPath(IEnumerable<string> lines, int maxRecurrance = 1000)
        {
            int guardPosX = -1;
            int guardPosY = -1;

            int minX = 0;
            int maxX = lines.First().Length - 1;
            int minY = 0;
            int maxY = lines.Count() - 1;

            for (var i = 0; i <= maxY; i++)
            {
                var line = lines.ElementAt(i);
                for (int j = 0; j <= maxX; j++)
                {
                    if (line[j] == '^')
                    {
                        guardPosX = j;
                        guardPosY = i;
                        break;
                    }
                }
            }

            List<Tuple<int, int>> visitedPoints = new List<Tuple<int, int>>() { new Tuple<int, int>(guardPosX, guardPosY) };
            int recurringVisitedPoints = 0;
            GuardView view = GuardView.Top;
            while (recurringVisitedPoints < maxRecurrance)
            {
                int nextPosX = -1;
                int nextPosY = -1;

                switch (view)
                {
                    case GuardView.Top:
                        nextPosX = guardPosX;
                        nextPosY = guardPosY - 1;
                        break;
                    case GuardView.Right:
                        nextPosX = guardPosX + 1;
                        nextPosY = guardPosY;
                        break;
                    case GuardView.Bottom:
                        nextPosX = guardPosX;
                        nextPosY = guardPosY + 1;
                        break;
                    case GuardView.Left:
                        nextPosX = guardPosX - 1;
                        nextPosY = guardPosY;
                        break;
                }

                if (nextPosX < minX || nextPosY < minY || nextPosX > maxX || nextPosY > maxY)
                    break;

                switch (lines.ElementAt(nextPosY)[nextPosX])
                {
                    case '^':
                    case '.':
                        //walk
                        guardPosX = nextPosX;
                        guardPosY = nextPosY;
                        var newPos = new Tuple<int, int>(nextPosX, nextPosY);
                        if (!visitedPoints.Contains(newPos))
                            visitedPoints.Add(newPos);
                        else
                        {
                            recurringVisitedPoints++;
                        }
                        break;
                    case '#':
                        //turn 90 degree right
                        view = (GuardView)(((int)view + 1) % 4);
                        break;
                }
            }

            if (recurringVisitedPoints >= maxRecurrance)
                return -1;

            return visitedPoints.Count();
        }

        internal enum GuardView
        {
            Top = 0,
            Right = 1,
            Bottom = 2,
            Left = 3,
        }

    }
}
