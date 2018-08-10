using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Compute CAPTCHA
/// http://adventofcode.com/2017/day/1
/// </summary>
namespace AdventOfCode.Puzzles2017
{
    public static class Day1
    {
        public static int Solve(string puzzleInput, int problemPart)
        {
            if (problemPart == 1)
                return _solve(puzzleInput, 1);
            else
                return _solve(puzzleInput, (puzzleInput.Length / 2));
        }

        public static int _solve(string puzzleInput, int indexIncrement)
        {
            var total = 0;
            var nextDigitToCheck = new char();
            var nextIndexToCheck = 0;

            for (int i = 0; i < puzzleInput.Length; i++)
            {
                nextIndexToCheck = i + (indexIncrement);

                if (nextIndexToCheck >= puzzleInput.Length)
                {
                    nextIndexToCheck = nextIndexToCheck - puzzleInput.Length;
                }

                nextDigitToCheck = puzzleInput[nextIndexToCheck];

                if (nextDigitToCheck == puzzleInput[i])
                {
                    total += int.Parse(puzzleInput[i].ToString());
                }
            }

            return total;
        }
    }
}
