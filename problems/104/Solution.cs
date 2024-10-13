namespace Problem_104;

using Helpers.TreeNode;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([3, 9, 20, null, null, 15, 7]);

        var solution = new Solution();
        Console.WriteLine(solution.MaxDepth(root));
    }
    public int MaxDepth(TreeNode root)
    {
        return DFS(root, 0);
    }

    private int DFS(TreeNode node, int length)
    {
        if (node is null) return length;
        return Math.Max(DFS(node.left, length + 1), DFS(node.right, length + 1));
    }
}