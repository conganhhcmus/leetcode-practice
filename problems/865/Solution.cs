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
    public TreeNode SubtreeWithAllDeepest(TreeNode root)
    {
        if (root is null) return null;
        int leftDepth = GetDepth(root.left);
        int rightDepth = GetDepth(root.right);
        if (leftDepth == rightDepth) return root;
        if (leftDepth > rightDepth) return SubtreeWithAllDeepest(root.left);
        return SubtreeWithAllDeepest(root.right);
    }

    int GetDepth(TreeNode root)
    {
        if (root is null) return 0;
        return Math.Max(GetDepth(root.left), GetDepth(root.right)) + 1;
    }
}