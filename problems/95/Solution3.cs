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
    public IList<TreeNode> GenerateTrees(int n)
    {
        // dp[i] = all tree from 1->i
        IList<TreeNode>[] dp = new IList<TreeNode>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dp[i] = [];
        }
        dp[0] = [null];
        for (int num = 1; num <= n; num++)
        {
            for (int i = 1; i <= num; i++)
            {
                int j = num - i;
                foreach (TreeNode left in dp[i - 1])
                {
                    foreach (TreeNode right in dp[j])
                    {
                        TreeNode root = new(i, left, Clone(right, i));
                        dp[num].Add(root);
                    }
                }
            }
        }
        return dp[n];
    }

    TreeNode Clone(TreeNode node, int offset)
    {
        if (node == null) return null;

        TreeNode clonedNode = new(node.val + offset);
        clonedNode.left = Clone(node.left, offset);
        clonedNode.right = Clone(node.right, offset);
        return clonedNode;
    }
}