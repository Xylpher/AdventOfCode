using AdventOfCode.Utils;

namespace AdventOfCode2023
{
    internal class Day4 : Day
    {
        public Day4() : base(4)
        {
        }

        public override string ProblemOne()
        {
            var score = 0;
            foreach (var card in lines)
            {
                var allNumbers = card.Split(':')[1].Split('|');
                var winningNumbers = allNumbers[0].Split(" ").ToList();
                var ownNumbers = allNumbers[1].Split(" ").ToList();

                winningNumbers.RemoveAll(x => x == "");
                ownNumbers.RemoveAll(x => x == "");

                var matches = winningNumbers.Count(x => ownNumbers.Contains(x));

                var cardScore = matches;
                //Up to 2 matches the cardscore is the same as the number of matches.
                //After that we can calculate it by raising 2 by the power of the matches-1, so the first doubling from 1 to 2 is accounted for
                if (matches > 2)
                {
                    cardScore = int.Parse(Math.Pow(2, matches - 1).ToString());
                }
                score += cardScore;
            }


            return score.ToString();
        }

        public override string ProblemTwo()
        {
            var score = 0;

            int lineCount = lines.Count();

            //Create Datasets for available scratchcards
            Dictionary<int, int> cardNumberToAmount = new Dictionary<int, int>();
            for (int i = 0; i < lineCount; i++)
            {
                cardNumberToAmount.Add(i, 1);
            }


            for (int i = 0; i < lineCount; i++)
            {
                var card = lines.ElementAt(i);

                var allNumbers = card.Split(':')[1].Split('|');
                var winningNumbers = allNumbers[0].Split(" ").ToList();
                var ownNumbers = allNumbers[1].Split(" ").ToList();

                winningNumbers.RemoveAll(x => x == "");
                ownNumbers.RemoveAll(x => x == "");

                var matches = winningNumbers.Count(x => ownNumbers.Contains(x));

                int numberOfCurrentScratchCard = cardNumberToAmount[i];

                for (int j = 1; j <= matches; j++)
                {
                    //So we dont create new Datasets at the end, for cards that dont exist
                    if (cardNumberToAmount.ContainsKey(i + j))
                    {
                        cardNumberToAmount[i + j] += numberOfCurrentScratchCard;
                    }
                }
            }

            for (int i = 0; i < lineCount; i++)
            {
                score += cardNumberToAmount[i];
            }

            return score.ToString();
        }
    }
}
