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
    public int MaxPathSum(TreeNode root)
    {
        int maxSum = int.MinValue;
        DFS(root, ref maxSum);
        return maxSum;
    }

    public int DFS(TreeNode root, ref int ans)
    {
        if (root == null) return int.MinValue / 3;
        int leftMax = DFS(root.left, ref ans);
        int rightMax = DFS(root.right, ref ans);
        int maxSum = Math.Max(root.val, Math.Max(root.val + leftMax, root.val + rightMax));
        ans = Math.Max(ans, Math.Max(leftMax, rightMax));
        ans = Math.Max(ans, Math.Max(maxSum, root.val + leftMax + rightMax));
        return maxSum;
    }
}