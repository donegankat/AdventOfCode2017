using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Calculate the number of steps it takes to balance the distribution of numbers across a list of memory blocks before hitting an infinite loop.
/// http://adventofcode.com/2017/day/6
/// </summary>
namespace AdventOfCode.Puzzles2017
{
    public class MemoryBlockList
    {
        public List<int> Blocks { get; set; }

        public MemoryBlockList()
        {
            Blocks = new List<int>();
        }
    }

    public static class Day6
    {
        public static int Solve(string puzzleInput)
        {
            var totalSteps = 1;
            var memoryBlockList = new List<MemoryBlockList>(); // Holds all of the lists of memory blocks and their values.
            var orginalMemoryBlocks = new MemoryBlockList(); // Only used to hold the initial input.

            foreach (var memoryBlock in puzzleInput.Split('\t', StringSplitOptions.RemoveEmptyEntries))
            {
                orginalMemoryBlocks.Blocks.Add(int.Parse(memoryBlock.Trim()));
            }

            memoryBlockList.Add(orginalMemoryBlocks);

            while (true)
            {
                var currentMemoryBlockList = memoryBlockList[memoryBlockList.Count() - 1]; // Subtract 1 to get 0-based index
                Dictionary<int, int> currentMemoryBlockArray = new Dictionary<int, int>();

                for (int i = 0; i < currentMemoryBlockList.Blocks.Count(); i++)
                {
                    currentMemoryBlockArray.Add(i, currentMemoryBlockList.Blocks[i]); // Get the list of values but preserve the original index ordering.
                }

                var highestBlock = currentMemoryBlockArray.OrderByDescending(x => x.Value).FirstOrDefault();
                var remainingValue = highestBlock.Value; // Get the current highest block value.
                currentMemoryBlockArray[highestBlock.Key] = 0; // Set the current highest block to 0.
                var currentIndex = highestBlock.Key + 1; // Begin with the block after the starting block.

                while (remainingValue > 0)
                {
                    if (currentIndex >= currentMemoryBlockArray.Count()) // Loop back to the beginning after we reach the end.
                        currentIndex = 0;

                    currentMemoryBlockArray[currentIndex]++;
                    remainingValue--; // Decrement the remaining value that we have left to distribute.
                    currentIndex++;
                }

                var updatedBlockList = new MemoryBlockList();
                foreach (var block in currentMemoryBlockArray)
                {
                    updatedBlockList.Blocks.Add(block.Value);
                }

                bool alreadyExists = true;
                foreach (var existingBlockList in memoryBlockList)
                {
                    alreadyExists = true; // Assume it's a repeat unless proven otherwise.

                    for (int i = 0; i < existingBlockList.Blocks.Count(); i++)
                    {
                        if (existingBlockList.Blocks[i] != updatedBlockList.Blocks[i]) // If even 1 digit differs then it's not a list we've seen before.
                        {
                            alreadyExists = false;
                            break;
                        }
                    }

                    if (alreadyExists) // Stop if we've hit a point we've already seen before. This means we've hit an infinite loop.
                        break;
                }

                if (alreadyExists)
                {
                    break;
                }
                else
                {
                    memoryBlockList.Add(updatedBlockList);
                    totalSteps++;
                }
            }

            return totalSteps;
        }
    }
}
