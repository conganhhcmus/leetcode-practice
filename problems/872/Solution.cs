namespace Problem_872;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var root1 = TreeNodeHelper.CreateTreeFromArray([3, 5, 1, 6, 2, 9, 8, null, null, 7, 4]);
        var root2 = TreeNodeHelper.CreateTreeFromArray([3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8]);

        var solution = new Solution();
        Console.WriteLine(solution.LeafSimilar(root1, root2));
    }
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        List<int> leaf1 = [];
        List<int> leaf2 = [];

        DFS(root1, leaf1);
        DFS(root2, leaf2);

        return leaf1.SequenceEqual(leaf2);
    }

    private void DFS(TreeNode node, List<int> leaf)
    {
        if (node is null) return;
        if (node.left is null && node.right is null)
        {
            leaf.Add(node.val);
            return;
        }

        DFS(node.left, leaf);
        DFS(node.right, leaf);
    }
}