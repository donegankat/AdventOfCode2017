using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Calculate the number of steps it takes to reach the beginning node of a spiral pattern.
/// http://adventofcode.com/2017/day/3
/// </summary>
namespace AdventOfCode.Puzzles2017
{
    public static class Day3
    {
        private enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }

        public static int Solve(string puzzleInput)
        {
            var intInput = int.Parse(puzzleInput);

            var spiral = new Dictionary<Tuple<int, int>, int>();
            var currentX = 0;
            var currentY = 0;
            var currentDirection = Direction.DOWN; // We'll start heading right immediately.

            for (int i = 1; i <= intInput; i++)
            {
                spiral.Add(new Tuple<int, int>(currentX, currentY), i);

                switch (currentDirection)
                {
                    case Direction.LEFT:
                        if (spiral.ContainsKey(new Tuple<int, int>(currentX, currentY - 1))) // The spot that would allow us to rotate 90 degrees to the left is taken. Continue with current direction.
                        {
                            currentX--;
                        }
                        else // We can rotate 90 degrees to the left. Change direction.
                        {
                            currentDirection = Direction.DOWN;
                            currentY--;
                        }
                        break;
                    case Direction.RIGHT:
                        if (spiral.ContainsKey(new Tuple<int, int>(currentX, currentY + 1))) // The spot that would allow us to rotate 90 degrees to the left is taken. Continue with current direction.
                        {
                            currentX++;
                        }
                        else // We can rotate 90 degrees to the left. Change direction.
                        {
                            currentDirection = Direction.UP;
                            currentY++;
                        }
                        break;
                    case Direction.DOWN:
                        if (spiral.ContainsKey(new Tuple<int, int>(currentX + 1, currentY))) // The spot that would allow us to rotate 90 degrees to the left is taken. Continue with current direction.
                        {
                            currentY--;
                        }
                        else // We can rotate 90 degrees to the left. Change direction.
                        {
                            currentDirection = Direction.RIGHT;
                            currentX++;
                        }
                        break;
                    case Direction.UP:
                        if (spiral.ContainsKey(new Tuple<int, int>(currentX - 1, currentY))) // The spot that would allow us to rotate 90 degrees to the left is taken. Continue with current direction.
                        {
                            currentY++;
                        }
                        else // We can rotate 90 degrees to the left. Change direction.
                        {
                            currentDirection = Direction.LEFT;
                            currentX--;
                        }
                        break;
                }
            }

            //_printBoard(spiral); // Print what we've made so far. This is time consuming so don't use it for larger spirals.

            // The goal is to calculate the distance from the puzzle input back to position 0,0
            var finalPosition = spiral.Where(x => x.Value == intInput).FirstOrDefault();
            var distanceToStart = Math.Abs(finalPosition.Key.Item1) + Math.Abs(finalPosition.Key.Item2);

            return distanceToStart;
        }

        private static void _printBoard(Dictionary<Tuple<int, int>, int> spiral)
        {
            var previousLine = 0;
            foreach (var coord in spiral.Keys.OrderByDescending(x => x.Item2).ThenBy(x => x.Item1)) // Print each line starting from the top (i.e. the highest Y coordinate.
            {
                if (previousLine != coord.Item2)
                {
                    Console.Write("\n");
                    previousLine = coord.Item2;
                }
                Console.Write(spiral.GetValueOrDefault(new Tuple<int, int>(coord.Item1, coord.Item2)) + "\t");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
