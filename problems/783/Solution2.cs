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
    private int min = int.MaxValue;
    private int prev = -1;

    public int MinDiffInBST(TreeNode root)
    {
        if (root == null) return min;
        MinDiffInBST(root.left);
        if (prev != -1)
        {
            min = Math.Min(min, root.val - prev);
        }
        prev = root.val;
        MinDiffInBST(root.right);
        return min;
    }
}