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
    public int MinDepth(TreeNode root)
    {
        if (root is null)
            return 0;
        int left = MinDepth(root.left);
        int right = MinDepth(root.right);
        if (root.left is null)
            return right + 1;
        if (root.right is null)
            return left + 1;
        return Math.Min(left, right) + 1;
    }
}
