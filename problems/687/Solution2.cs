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
    public int LongestUnivaluePath(TreeNode root)
    {
        int ans = 0;
        Dfs(root, -1001);
        return ans;

        int Dfs(TreeNode root, int val)
        {
            if (root is null) return 0;
            int l = Dfs(root.left, root.val);
            int r = Dfs(root.right, root.val);

            ans = Math.Max(ans, l + r);

            return root.val == val ? Math.Max(l, r) + 1 : 0;
        }
    }
}
