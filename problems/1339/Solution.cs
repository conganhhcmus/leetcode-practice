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
    public int MaxProduct(TreeNode root)
    {
        int mod = (int)1e9 + 7;
        long ans = 0;
        List<long> set = [];
        long total = SumSubTree(root, set);
        foreach (long val in set)
        {
            ans = Math.Max(ans, (total - val) * val);
        }

        return (int)(ans % mod);
    }

    long SumSubTree(TreeNode root, List<long> set)
    {
        if (root == null) return 0;
        long ans = 0;
        ans += root.val;
        ans += SumSubTree(root.left, set);
        ans += SumSubTree(root.right, set);
        set.Add(ans);
        return ans;
    }
}