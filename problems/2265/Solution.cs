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
    public int AverageOfSubtree(TreeNode root)
    {
        if (root == null) return 0;
        int avg = Sum(root) / Count(root);
        int ans = 0;
        if (root.val == avg) ans++;
        ans += AverageOfSubtree(root.left);
        ans += AverageOfSubtree(root.right);
        return ans;
    }

    int Sum(TreeNode root)
    {
        if (root == null) return 0;
        return root.val + Sum(root.left) + Sum(root.right);
    }

    int Count(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + Count(root.left) + Count(root.right);
    }
}