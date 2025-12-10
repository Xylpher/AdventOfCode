using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day10 : Day
    {
        Dictionary<bool[], int> buttonPressesForLightStates;

        bool[] ExpectedResultLights;

        public Day10() : base(10)
        {
        }

        public override string ProblemOne()
        {
            long result = 0;
            foreach (var line in lines)
            {
                bool[] currentlyActiveLights;
                List<int[]> buttons = new List<int[]>();

                var splits = line.Split(' ');

                ExpectedResultLights = splits[0].Substring(1, splits[0].Length - 2).Select(x => x == '#').ToArray();
                currentlyActiveLights = new bool[ExpectedResultLights.Length];

                buttonPressesForLightStates = new Dictionary<bool[], int>();
                buttonPressesForLightStates.Add(currentlyActiveLights.ToArray(), 0);
                for (int i = 1; i < splits.Length - 1; i++)
                {
                    var buttonControl = splits[i].Substring(1, splits[i].Length - 2).Split(',').Select(x => Int32.Parse(x)).ToArray();
                    buttons.Add(buttonControl);
                }

                foreach (var button in buttons)
                {
                    var possibleButtons = buttons.ToList();
                    possibleButtons.Remove(button);
                    PressButtonLights(button, currentlyActiveLights.ToArray(), possibleButtons, 1);
                }

                result += buttonPressesForLightStates[ExpectedResultLights];
            }

            return result.ToString();
        }

        private void PressButtonLights(int[] button, bool[] currentState, IEnumerable<int[]> possibleButtonsNext, int iteration)
        {
            var newState = currentState.ToArray();
            foreach (var index in button)
                newState[index] = !currentState[index];

            bool isExpectedResult = Enumerable.SequenceEqual(newState, ExpectedResultLights);

            if (isExpectedResult)
            {
                if (buttonPressesForLightStates.ContainsKey(ExpectedResultLights))
                {
                    if (buttonPressesForLightStates[ExpectedResultLights] > iteration)
                        buttonPressesForLightStates[ExpectedResultLights] = iteration;
                }
                else
                {
                    buttonPressesForLightStates.Add(ExpectedResultLights, iteration);
                }
                return;
            }
            else
            {
                if (buttonPressesForLightStates.ContainsKey(ExpectedResultLights) && buttonPressesForLightStates[ExpectedResultLights] <= iteration)
                    return;

                var key = buttonPressesForLightStates.Keys.Where(x => Enumerable.SequenceEqual(newState, x)).FirstOrDefault();
                if (key != null)
                {
                    if (buttonPressesForLightStates[key] > iteration)
                        buttonPressesForLightStates[key] = iteration;
                    else
                        return;
                }
                else
                {
                    buttonPressesForLightStates.Add(newState, iteration);
                }
            }

            foreach (var nextButton in possibleButtonsNext)
            {
                var possibleButtons = possibleButtonsNext.ToList();
                possibleButtons.Remove(nextButton);
                PressButtonLights(nextButton, newState, possibleButtons, iteration + 1);
            }
        }
    }
}


