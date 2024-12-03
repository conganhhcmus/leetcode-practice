namespace Problem_1448;

public class Solution
{
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