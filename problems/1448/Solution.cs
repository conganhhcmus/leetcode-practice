namespace Problem_1448;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([-1, 5, -2, 4, 4, 2, -2, null, null, -4, null, -2, 3, null, -2, 0, null, -1, null, -3, null, -4, -3, 3, null, null, null, null, null, null, null, 3, -3]);
        var solution = new Solution();
        Console.WriteLine(solution.GoodNodes(root));
    }
    public int GoodNodes(TreeNode root)
    {
        return DFS(root, int.MinValue);
    }

    private int DFS(TreeNode node, int maxValue)
    {
        if (node is null) return 0;

        if (node.val >= maxValue)
        {
            maxValue = node.val;
            return DFS(node.left, maxValue) + DFS(node.right, maxValue) + 1;
        }

        return DFS(node.left, maxValue) + DFS(node.right, maxValue);
    }
}