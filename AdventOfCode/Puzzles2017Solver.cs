using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AdventOfCode.Puzzles2017;
using System.IO;

namespace AdventOfCode
{
    public static class Puzzles2017Solver
    {
        private static string _currentDirectory = Directory.GetCurrentDirectory();
        private static string _rootProjectDirectory = _currentDirectory.Remove(_currentDirectory.IndexOf("\\bin"));

        public static void Solve(int day, int problemPart)
        {
            var puzzleInput = _loadFileInput(day);
            var solution = 0;

            switch (day)
            {
                case 1:
                    solution = Day1.Solve(puzzleInput, problemPart);
                    break;
                case 2:
                    solution = Day2.Solve(puzzleInput, problemPart);
                    break;
                case 3:
                    solution = Day3.Solve(puzzleInput);
                    break;
                case 4:
                    solution = Day4.Solve(puzzleInput);
                    break;
                case 5:
                    solution = Day5.Solve(puzzleInput);
                    break;
                case 6:
                    solution = Day6.Solve(puzzleInput);
                    break;
                case 7:
                    solution = Day7.Solve(puzzleInput);
                    break;
                case 8:
                    solution = Day8.Solve(puzzleInput);
                    break;
                case 9:
                    throw new NotImplementedException();
                    break;
                case 10:
                    throw new NotImplementedException();
                    break;
                case 11:
                    throw new NotImplementedException();
                    break;
                case 12:
                    throw new NotImplementedException();
                    break;
                case 13:
                    throw new NotImplementedException();
                    break;
                case 14:
                    throw new NotImplementedException();
                    break;
                case 15:
                    throw new NotImplementedException();
                    break;
                case 16:
                    throw new NotImplementedException();
                    break;
                case 17:
                    throw new NotImplementedException();
                    break;
                case 18:
                    throw new NotImplementedException();
                    break;
                case 19:
                    throw new NotImplementedException();
                    break;
                case 20:
                    throw new NotImplementedException();
                    break;
                case 21:
                    throw new NotImplementedException();
                    break;
                case 22:
                    throw new NotImplementedException();
                    break;
                case 23:
                    throw new NotImplementedException();
                    break;
                case 24:
                    throw new NotImplementedException();
                    break;
                case 25:
                    throw new NotImplementedException();
                    break;
                default:
                    Console.WriteLine("ERROR: Inavlid day");
                    break;
            }

            Console.WriteLine($"Puzzle Solution: {solution}");
        }

        private static string _loadFileInput(int day)
        {
            return File.ReadAllText($"{_rootProjectDirectory}/Puzzles2017/Inputs/Day{day}.txt");
        }
    }
}
