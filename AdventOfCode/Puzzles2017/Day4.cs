using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Find valid passphrases.
/// http://adventofcode.com/2017/day/4
/// </summary>
namespace AdventOfCode.Puzzles2017
{
    public static class Day4
    {
        public static int Solve(string puzzleInput)
        {
            var numValidPassphrases = 0;
            foreach (var passphrase in puzzleInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                var isValidPassphrase = true;
                var passwords = passphrase.Trim().Split(' ');
                
                for (int i = 0; i < passwords.Length - 1; i++)
                {
                    for (int j = i + 1; j < passwords.Length; j++)
                    {
                        // Anagrams count as invalid, so order each password by characters to make anagram comparison possible.
                        // UPDATE: This actually isn't true but I kinda like the anagram checking. Not deleting yet but not using it.
                        //var iOrdered = new string(passwords[i].OrderBy(x => x).ToArray());
                        //var jOrdered = new string(passwords[j].OrderBy(x => x).ToArray());

                        if (passwords[i] == passwords[j])
                        {
                            isValidPassphrase = false;
                            break;
                        }
                    }

                    if (!isValidPassphrase)
                        break;
                }

                if (isValidPassphrase)
                    numValidPassphrases++;
            }

            return numValidPassphrases;
        }
    }
}
