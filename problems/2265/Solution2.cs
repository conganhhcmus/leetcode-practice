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
        int cnt = 0;
        Dfs(root);

        return cnt;

        (int sum, int size) Dfs(TreeNode root)
        {
            if (root == null) return (0, 0);
            var left = Dfs(root.left);
            var right = Dfs(root.right);
            int sum = root.val + left.sum + right.sum;
            int size = 1 + left.size + right.size;
            if (root.val == sum / size) cnt++;
            return (sum, size);
        }
    }
}