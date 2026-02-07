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
    public int Rob(TreeNode root)
    {
        return DP(root)[0];
    }

    int[] DP(TreeNode root)
    {
        int[] ans = new int[2];
        if (root == null) return ans;
        int[] left = DP(root.left);
        int[] right = DP(root.right);
        ans[0] = Math.Max(left[0] + right[0], left[1] + right[1] + root.val);
        ans[1] = left[0] + right[0];
        return ans;
    }
}