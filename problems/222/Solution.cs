/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public int CountNodes(TreeNode root)
    {
        if (root == null) return 0;
        int hLeft = GetHeightLeft(root);
        int hRight = GetHeightRight(root);
        if (hLeft == hRight) return (1 << hLeft) - 1;
        return CountNodes(root.left) + CountNodes(root.right) + 1;
    }

    private int GetHeightLeft(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + GetHeightLeft(root.left);
    }

    private int GetHeightRight(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + GetHeightRight(root.right);
    }
}