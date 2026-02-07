public class Solution
{
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