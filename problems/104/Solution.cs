public class Solution
{
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