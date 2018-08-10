using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Compute checksum
/// http://adventofcode.com/2017/day/2
/// </summary>
namespace AdventOfCode.Puzzles2017
{
    public static class Day2
    {
        public static int Solve(string puzzleInput, int problemPart)
        {
            if (problemPart == 1)
                return _solve(puzzleInput, 1);
            else
                return _solve(puzzleInput, 1);
        }

        public static int _solve(string puzzleInput, int dontknowyet)
        {
            var total = 0;

            foreach (var line in puzzleInput.Split(Environment.NewLine.ToCharArray()))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var lowestInt = int.MaxValue;
                var highestInt = 0;

                foreach (var number in line.Split('\t'))
                {
                    if (int.TryParse(number, out int parsedNumber))
                    {
                        if (lowestInt > parsedNumber)
                            lowestInt = parsedNumber;
                        if (highestInt < parsedNumber)
                            highestInt = parsedNumber;
                    }
                }

                total += highestInt - lowestInt;
            }

            return total;
        }
    }
}
