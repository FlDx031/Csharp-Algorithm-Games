using System;
using System.Collections.Generic;

class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

class BinaryTreePathFinder
{
    public static List<List<int>> FindPaths(TreeNode root) 
    {
        List<List<int>> result = new List<List<int>>();
        if (root == null)
            return result;

        List<int> currentPath = new List<int>();
        TraverseTree(root, currentPath, result);
        return result;
    }

    private static void TraverseTree(TreeNode node, List<int> currentPath, List<List<int>> result) 
    {
        if (node == null)
            return;

        // Add current node to the path
        currentPath.Add(node.Value);

        // If it's a leaf node, save the current path
        if (node.Left == null && node.Right == null)
        {
            result.Add(new List<int>(currentPath));
        }
        else
        {
            // Traverse left and right subtrees
            TraverseTree(node.Left, currentPath, result);
            TraverseTree(node.Right, currentPath, result);
        }

        // Backtrack by removing the current node
        currentPath.RemoveAt(currentPath.Count - 1);
    }

    public static void Main(string[] args)
    {
        // Build the example tree:
        //        1
        //       / \
        //      2   3
        //     / \   \
        //    4   5   6
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Right.Right = new TreeNode(6);

        // Find and print all paths
        List<List<int>> paths = FindPaths(root);
        Console.WriteLine(paths); // Output: [[1, 2, 4], [1, 2, 5], [1, 3, 6]]
    }
}
