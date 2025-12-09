using AdventOfCode.Utils;
using System.Drawing;

namespace AdventOfCode2025
{
    internal class Day9 : Day
    {
        List<Point> tiles = new List<Point>();
        List<Tuple<Point, Point, LineOrientation>> pointLines = new List<Tuple<Point, Point, LineOrientation>>();

        public Day9() : base(9)
        {
            Point? firstPoint = null;
            foreach (var line in lines)
            {
                var split = line.Split(',');
                tiles.Add(new Point(Convert.ToInt32(split[0]), Convert.ToInt32(split[1])));
            }

            Point p1;
            Point p2;

            for (int i = 0; i < tiles.Count() - 1; i++)
            {
                p1 = tiles[i];
                p2 = tiles[i + 1];
                if (p1.X == p2.X)
                    pointLines.Add(Tuple.Create(p1, p2, LineOrientation.Vertical));
                else
                    pointLines.Add(Tuple.Create(p1, p2, LineOrientation.Horizontal));
            }

            p1 = tiles[tiles.Count() - 1];
            p2 = tiles[0];
            if (p1.X == p2.X)
                pointLines.Add(Tuple.Create(p1, p2, LineOrientation.Vertical));
            else
                pointLines.Add(Tuple.Create(p1, p2, LineOrientation.Horizontal));
        }

        public override string ProblemOne()
        {
            long result = 0;
            long maxArea = 0;

            for (int i = 0; i < tiles.Count() - 1; i++)
            {
                var p1 = tiles[i];
                for (int j = i + 1; j < tiles.Count(); j++)
                {
                    var p2 = tiles[j];
                    var area = GetArea(p1, p2);
                    if (area > maxArea)
                        maxArea = area;
                }
            }

            result = maxArea;
            return result.ToString();
        }

        public override string ProblemTwo()
        {
            long result = 0;
            long maxArea = 0;

            for (int i = 0; i < tiles.Count() - 1; i++)
            {
                var p1 = tiles[i];
                for (int j = i + 1; j < tiles.Count(); j++)
                {
                    var p2 = tiles[j];
                    var area = GetArea(p1, p2);
                    if (area > maxArea)
                    {
                        int maxX = Math.Max(p1.X, p2.X);
                        int minX = Math.Min(p1.X, p2.X);
                        int maxY = Math.Max(p1.Y, p2.Y);
                        int minY = Math.Min(p1.Y, p2.Y);

                        var pointTopLeft = new Point(minX, minY);
                        var pointTopRight = new Point(maxX, minY);
                        var pointBottomRight = new Point(maxX, maxY);
                        var pointBottomLeft = new Point(minX, maxY);

                        if (!IsCutByLineOrOutOfRange(pointTopLeft, pointTopRight, pointBottomLeft, pointBottomRight))
                            maxArea = area;
                    }
                }
            }
            result = maxArea;


            return result.ToString();
        }

        private bool IsCutByLineOrOutOfRange(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight)
        {
            //Check all Corners are inside the range
            if (!tiles.Any(x => x.X <= topLeft.X && x.Y <= topLeft.Y))
                return true;

            if (!tiles.Any(x => x.X >= topRight.X && x.Y <= topRight.Y))
                return true;

            if (!tiles.Any(x => x.X <= bottomLeft.X && x.Y >= bottomLeft.Y))
                return true;

            if (!tiles.Any(x => x.X >= bottomRight.X && x.Y >= bottomRight.Y))
                return true;


            //left line
            var counterLines = pointLines.Where(x => x.Item3 == LineOrientation.Horizontal
             && (((x.Item1.X < topLeft.X && x.Item2.X > topLeft.X) || (x.Item1.X > topLeft.X && x.Item2.X < topLeft.X))
             && ((x.Item1.Y < topLeft.Y && x.Item1.Y > bottomLeft.Y) || (x.Item1.Y > topLeft.Y && x.Item1.Y < bottomLeft.Y))));
            if (counterLines.Any())
                return true;

            //rightLine
            counterLines = pointLines.Where(x => x.Item3 == LineOrientation.Horizontal
              && (((x.Item1.X < topRight.X && x.Item2.X > topRight.X) || (x.Item1.X > topRight.X && x.Item2.X < topRight.X))
              && ((x.Item1.Y < topRight.Y && x.Item1.Y > bottomRight.Y) || (x.Item1.Y > topRight.Y && x.Item1.Y < bottomRight.Y))));
            if (counterLines.Any())
                return true;

            //topLine
            counterLines = pointLines.Where(x => x.Item3 == LineOrientation.Vertical
              && (((x.Item1.X < topRight.X && x.Item1.X > topLeft.X) || (x.Item1.X < topLeft.X && x.Item1.X > topRight.X))
              && ((x.Item1.Y > topRight.Y && x.Item2.Y < topRight.Y) || (x.Item1.Y < topRight.Y && x.Item2.Y > topRight.Y))));
            if (counterLines.Any())
                return true;

            //bottomLine
            counterLines = pointLines.Where(x => x.Item3 == LineOrientation.Vertical
              && (((x.Item1.X < bottomRight.X && x.Item1.X > bottomLeft.X) || (x.Item1.X < bottomLeft.X && x.Item1.X > bottomRight.X))
              && ((x.Item1.Y > bottomRight.Y && x.Item2.Y < bottomRight.Y) || (x.Item1.Y < bottomRight.Y && x.Item2.Y > bottomRight.Y))));
            if (counterLines.Any())
                return true;

            return false;
        }

        private long GetArea(Point p1, Point p2)
        {
            long xDif = (Math.Abs(p1.X - p2.X) + 1);
            long yDif = (Math.Abs(p1.Y - p2.Y) + 1);
            long area = xDif * yDif;
            return area;
        }

        internal enum LineOrientation
        {
            Horizontal,
            Vertical
        }
    }
}

