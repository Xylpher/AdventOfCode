using AdventOfCode.Utils;

namespace AdventOfCode2024
{
    internal class Day1 : Day
    {
        public Day1() : base(1)
        {
        }

        public override string ProblemOne()
        {
            var score = 0;
            foreach (var line in lines)
            {
                char left = ' ';
                char right = ' ';
                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        if (left == ' ')
                            left = c;
                        right = c;
                    }
                }

                int value = int.Parse($"{left}{right}");
                score += value;

            }
            return score.ToString();
        }

        public override string ProblemTwo()
        {
            var score = 0;
            foreach (var line in lines)
            {
                char left = ' ';
                char right = ' ';
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (char.IsDigit(c))
                    {
                        if (left == ' ')
                            left = c;
                        right = c;
                    }
                    else
                    {
                        try
                        {
                            switch (c)
                            {
                                case 'o':
                                    if (line.Substring(i, 3) == "one")
                                    {
                                        if (left == ' ')
                                            left = '1';
                                        right = '1';
                                    }
                                    break;
                                case 't':
                                    if (line.Substring(i, 3) == "two")
                                    {
                                        if (left == ' ')
                                            left = '2';
                                        right = '2';
                                        i++;
                                        break;
                                    }
                                    if (line.Substring(i, 5) == "three")
                                    {
                                        if (left == ' ')
                                            left = '3';
                                        right = '3';
                                        i += 3;
                                    }
                                    break;
                                case 'f':
                                    if (line.Substring(i, 4) == "four")
                                    {
                                        if (left == ' ')
                                            left = '4';
                                        right = '4';
                                        i += 2;
                                        break;
                                    }
                                    if (line.Substring(i, 4) == "five")
                                    {
                                        if (left == ' ')
                                            left = '5';
                                        right = '5';
                                        i += 2;
                                    }
                                    break;
                                case 's':
                                    if (line.Substring(i, 3) == "six")
                                    {
                                        if (left == ' ')
                                            left = '6';
                                        right = '6';
                                        i++;
                                        break;
                                    }
                                    if (line.Substring(i, 5) == "seven")
                                    {
                                        if (left == ' ')
                                            left = '7';
                                        right = '7';
                                        i += 3;
                                    }
                                    break;
                                case 'e':
                                    if (line.Substring(i, 5) == "eight")
                                    {
                                        if (left == ' ')
                                            left = '8';
                                        right = '8';
                                        i += 3;
                                    }
                                    break;
                                case 'n':
                                    if (line.Substring(i, 4) == "nine")
                                    {
                                        if (left == ' ')
                                            left = '9';
                                        right = '9';
                                        i += 2;
                                    }
                                    break;
                            }
                        }
                        catch { }
                    }
                }

                int value = int.Parse($"{left}{right}");
                score += value;

            }
            return score.ToString();
        }
    }
}
