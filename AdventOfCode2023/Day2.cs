using AdventOfCode.Utils;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    internal class Day2 : Day
    {
        public Day2() : base(2)
        {
        }

        public override string ProblemOne()
        {
            var score = 0;

            int redMax = 12;
            int greenMax = 13;
            int blueMax = 14;
            var redRegex = new Regex(@"\d{1,2} red");
            var greenRegex = new Regex(@"\d{1,2} green");
            var blueRegex = new Regex(@"\d{1,2} blue");

            for (int i = 0; i < lines.Count(); i++)
            {
                var gameData = lines.ElementAt(i).Split(':')[1];
                var gameSuccess = true;
                var reveals = gameData.Split(";");

                foreach (var reveal in reveals)
                {
                    Match match = redRegex.Match(reveal);
                    if (match.Success)
                    {
                        var amount = int.Parse(match.Value.Substring(0, 2));
                        if (amount > redMax)
                            gameSuccess = false;
                    }
                    match = greenRegex.Match(reveal);
                    if (match.Success)
                    {
                        var amount = int.Parse(match.Value.Substring(0, 2));
                        if (amount > greenMax)
                            gameSuccess = false;
                    }
                    match = blueRegex.Match(reveal);
                    if (match.Success)
                    {
                        var amount = int.Parse(match.Value.Substring(0, 2));
                        if (amount > blueMax)
                            gameSuccess = false;
                    }
                }

                if (gameSuccess)
                    score += i + 1;
            }

            return score.ToString();
        }

        public override string ProblemTwo()
        {
            var score = 0;
            var redRegex = new Regex(@"\d{1,2} red");
            var greenRegex = new Regex(@"\d{1,2} green");
            var blueRegex = new Regex(@"\d{1,2} blue");

            foreach (var line in lines)
            {
                var gameData = line.Split(':')[1];
                var reveals = gameData.Split(";");

                int redMin = 0;
                int greenMin = 0;
                int blueMin = 0;
                foreach (var reveal in reveals)
                {
                    Match match = redRegex.Match(reveal);
                    if (match.Success)
                    {
                        var amount = int.Parse(match.Value.Substring(0, 2));
                        if (amount > redMin)
                            redMin = amount;
                    }
                    match = greenRegex.Match(reveal);
                    if (match.Success)
                    {
                        var amount = int.Parse(match.Value.Substring(0, 2));
                        if (amount > greenMin)
                            greenMin = amount;
                    }
                    match = blueRegex.Match(reveal);
                    if (match.Success)
                    {
                        var amount = int.Parse(match.Value.Substring(0, 2));
                        if (amount > blueMin)
                            blueMin = amount;
                    }
                }

                var gamescore = redMin * greenMin * blueMin;

                score += gamescore;
            }

            return score.ToString();
        }
    }
}
