using AdventOfCode.Utils;

namespace AdventOfCode2024
{
    internal class Day4 : Day
    {
        int lineLenght;

        public Day4() : base(4)
        {
            lineLenght = lines.First().Length;
        }

        #region Star1

        public override string ProblemOne()
        {
            var result = 0;

            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'X')
                    {
                        result += CheckHorizontal(line, j);
                        result += CheckVertical(i, j);
                        result += CheckDiagonal(i, j);
                    }
                }
            }
            return result.ToString();
        }

        private int CheckHorizontal(string line, int startIndex)
        {
            int xmasFound = 0;
            if (startIndex - 3 >= 0)
            {
                if (line[startIndex - 3] == 'S'
                    && line[startIndex - 2] == 'A'
                    && line[startIndex - 1] == 'M')
                {
                    xmasFound++;
                }
            }
            if (startIndex + 3 < line.Length)
            {
                if (line[startIndex + 1] == 'M'
                    && line[startIndex + 2] == 'A'
                    && line[startIndex + 3] == 'S')
                {
                    xmasFound++;
                }
            }
            return xmasFound;
        }

        private int CheckVertical(int lineIndex, int inlineIndex)
        {
            int xmasFound = 0;
            if (lineIndex - 3 >= 0)
            {
                if (lines.ElementAt(lineIndex - 3)[inlineIndex] == 'S'
                    && lines.ElementAt(lineIndex - 2)[inlineIndex] == 'A'
                    && lines.ElementAt(lineIndex - 1)[inlineIndex] == 'M')
                    xmasFound++;
            }
            if (lineIndex + 3 < lines.Count())
            {
                if (lines.ElementAt(lineIndex + 1)[inlineIndex] == 'M'
                    && lines.ElementAt(lineIndex + 2)[inlineIndex] == 'A'
                    && lines.ElementAt(lineIndex + 3)[inlineIndex] == 'S')
                    xmasFound++;
            }
            return xmasFound;
        }

        private int CheckDiagonal(int lineIndex, int inlineIndex)
        {
            int xmasFound = 0;
            //to topleft
            if (lineIndex - 3 >= 0 && inlineIndex - 3 >= 0)
            {
                if (lines.ElementAt(lineIndex - 3)[inlineIndex - 3] == 'S'
                    && lines.ElementAt(lineIndex - 2)[inlineIndex - 2] == 'A'
                    && lines.ElementAt(lineIndex - 1)[inlineIndex - 1] == 'M')
                    xmasFound++;
            }
            //to topright
            if (lineIndex - 3 >= 0 && inlineIndex + 3 < lineLenght)
            {
                if (lines.ElementAt(lineIndex - 3)[inlineIndex + 3] == 'S'
                    && lines.ElementAt(lineIndex - 2)[inlineIndex + 2] == 'A'
                    && lines.ElementAt(lineIndex - 1)[inlineIndex + 1] == 'M')
                    xmasFound++;
            }
            //to bottomright
            if (lineIndex + 3 < lines.Count() && inlineIndex + 3 < lineLenght)
            {
                if (lines.ElementAt(lineIndex + 1)[inlineIndex + 1] == 'M'
                    && lines.ElementAt(lineIndex + 2)[inlineIndex + 2] == 'A'
                    && lines.ElementAt(lineIndex + 3)[inlineIndex + 3] == 'S')
                    xmasFound++;
            }
            //to bottomleft
            if (lineIndex + 3 < lines.Count() && inlineIndex - 3 >= 0)
            {
                if (lines.ElementAt(lineIndex + 1)[inlineIndex - 1] == 'M'
                    && lines.ElementAt(lineIndex + 2)[inlineIndex - 2] == 'A'
                    && lines.ElementAt(lineIndex + 3)[inlineIndex - 3] == 'S')
                    xmasFound++;
            }
            return xmasFound;
        }

        #endregion

        #region Star2

        public override string ProblemTwo()
        {
            var result = 0;

            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'A' && CheckDiagonalXmas(i, j))
                    {
                        result++;
                    }
                }
            }
            return result.ToString();
        }

        private bool CheckDiagonalXmas(int lineIndex, int inlineIndex)
        {
            bool bottomLeftToTopRight = false;
            bool topLeftToBottomRight = false;
            if (lineIndex - 1 >= 0 && lineIndex + 1 < lines.Count()
                && inlineIndex - 1 >= 0 && inlineIndex + 1 < lineLenght)
            {
                if ((lines.ElementAt(lineIndex - 1)[inlineIndex - 1] == 'M'
                    && lines.ElementAt(lineIndex + 1)[inlineIndex + 1] == 'S')
                    ||
                    (lines.ElementAt(lineIndex - 1)[inlineIndex - 1] == 'S'
                    && lines.ElementAt(lineIndex + 1)[inlineIndex + 1] == 'M'))
                    topLeftToBottomRight = true;

                if ((lines.ElementAt(lineIndex + 1)[inlineIndex - 1] == 'M'
                    && lines.ElementAt(lineIndex - 1)[inlineIndex + 1] == 'S')
                    ||
                    (lines.ElementAt(lineIndex + 1)[inlineIndex - 1] == 'S'
                    && lines.ElementAt(lineIndex - 1)[inlineIndex + 1] == 'M'))
                    bottomLeftToTopRight = true;
            }

            return bottomLeftToTopRight && topLeftToBottomRight;
        }

        #endregion
    }
}
