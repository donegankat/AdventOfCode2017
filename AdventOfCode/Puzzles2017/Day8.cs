using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Calculate the number of steps it takes to jump through a list of instructions.
/// http://adventofcode.com/2017/day/8
/// </summary>
namespace AdventOfCode.Puzzles2017
{
    public static class Day8
    {
        public static int Solve(string puzzleInput)
        {
            var totalSteps = 0;
            var currentStepIndex = 0;
            var nextStepIndex = 0;
            var allSteps = new List<int>();

            foreach (var instructionStep in puzzleInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                allSteps.Add(int.Parse(instructionStep.Trim()));
            }

            while (true)
            {
                try
                {
                    nextStepIndex += allSteps[currentStepIndex]; // The next step index is the current step index + the value of the current step.
                    allSteps[currentStepIndex]++; // Increment the current value.
                    currentStepIndex = nextStepIndex; // Go to the next step.
                    totalSteps++;
                }
                catch (Exception ex) // We're expecting to hit an ArgumentOutOfRangeException exception eventually. That's when we know we're done.
                {
                    break;
                }
            }

            return totalSteps;
        }
    }
}
