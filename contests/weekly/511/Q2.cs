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
    public int CountDominantNodes(TreeNode root)
    {
        var (cnt, _) = Dfs(root);
        return cnt;

        (int cnt, int max) Dfs(TreeNode root)
        {
            if (root == null) return (0, 0);
            var (cntL, maxL) = Dfs(root.left);
            var (cntR, maxR) = Dfs(root.right);
            int max = Math.Max(root.val, Math.Max(maxL, maxR));
            int cnt = cntL + cntR + (root.val == max ? 1 : 0);
            return (cnt, max);
        }
    }
}
