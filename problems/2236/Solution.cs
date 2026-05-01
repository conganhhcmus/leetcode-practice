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
    public bool CheckTree(TreeNode root)
    {
        int left = root.left == null ? 0 : root.left.val;
        int right = root.right == null ? 0 : root.right.val;
        return left + right == root.val;
    }
}
