using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which day do you want to solve?");
            var input = Console.ReadLine();
            int parsedInputDay;
            int parsedInputPart;

            if (int.TryParse(input, out parsedInputDay))
            {
                if (parsedInputDay > 0 && parsedInputDay <= 25)
                {
                    Console.WriteLine("Which part do you want to solve? (1 or 2)");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input)) // If the user just pressed "Enter" default to solving part 1.
                    {
                        input = "1";
                    }

                    if (int.TryParse(input, out parsedInputPart))
                    {
                        Puzzles2017Solver.Solve(parsedInputDay, parsedInputPart);
                    }
                    else
                    {
                        Console.WriteLine("Invalid problem part");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input: day was outside of valid range");
                }
            }
            else
            {
                Console.WriteLine("Invalid input: not a valid integer");
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Process complete. Press any key to exit");
            Console.ReadKey();
        }
    }
}
