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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        IList<IList<int>> ans = [];
        Dfs(root, targetSum, []);

        return ans;

        void Dfs(TreeNode root, int rem, List<int> cur)
        {
            if (root == null) return;
            cur.Add(root.val);
            rem -= root.val;
            if (root.left == null && root.right == null && rem == 0)
            {
                ans.Add([.. cur]);
            }

            Dfs(root.left, rem, cur);
            Dfs(root.right, rem, cur);
            cur.RemoveAt(cur.Count - 1);
        }
    }
}
