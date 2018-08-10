using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Find the name of the base parent node of a tree.
/// http://adventofcode.com/2017/day/7
/// </summary>
namespace AdventOfCode.Puzzles2017
{
    public class TreeNode
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<string> Children { get; set; } // Only the immediate children.

        public TreeNode()
        {
            Children = new List<string>();
        }
    }

    public static class Day7
    {
        public static int Solve(string puzzleInput)
        {
            var tree = new List<TreeNode>();

            foreach (var line in puzzleInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                var newNode = new TreeNode
                {
                    Name = new string(line.Trim().TakeWhile(x => x != ' ').ToArray()).Trim(),
                };
                var weightStart = line.Substring(line.IndexOf('(') + 1);
                var weightEnd = weightStart.Remove(weightStart.IndexOf(')'));
                newNode.Weight = int.Parse(weightEnd);

                if (line.Contains("->"))
                {
                    foreach (var child in line.Substring(line.IndexOf("->") + 2).Split(',', StringSplitOptions.RemoveEmptyEntries))
                    {
                        newNode.Children.Add(child.Trim());
                    }
                }

                tree.Add(newNode);
            }

            var parentNodes = tree.Where(x => x.Children.Count() > 0).ToList();
            
            var baseNode = _getBaseParent(parentNodes, parentNodes.FirstOrDefault());

            Console.WriteLine($"Base Node Name: {baseNode.Name}");
            return 0;
        }

        private static TreeNode _getBaseParent(List<TreeNode> tree, TreeNode currentNode)
        {
            var parentNode = tree.Where(x => x.Children.Contains(currentNode.Name)).FirstOrDefault();
            if (parentNode != null)
            {
                return _getBaseParent(tree, parentNode);
            }
            return currentNode;
        }
    }
}
