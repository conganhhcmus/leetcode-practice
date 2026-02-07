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
        // dp[i][j] = all trees from i to j
        // dp[i][j] = 
        IList<TreeNode>[][] dp = new IList<TreeNode>[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new IList<TreeNode>[n + 1];
            for (int j = 0; j <= n; j++)
            {
                dp[i][j] = [];
            }
        }

        for (int i = 1; i <= n; i++)
        {
            dp[i][i].Add(new(i));
        }

        for (int num = 2; num <= n; num++)
        {
            for (int start = 1; start <= n - num + 1; start++)
            {
                int end = start + num - 1;
                for (int i = start; i <= end; i++)
                {
                    IList<TreeNode> left = (i != start) ? dp[start][i - 1] : [];
                    if (left.Count == 0)
                    {
                        left.Add(null);
                    }
                    IList<TreeNode> right = (i != end) ? dp[i + 1][end] : [];
                    if (right.Count == 0)
                    {
                        right.Add(null);
                    }
                    foreach (TreeNode leftNode in left)
                    {
                        foreach (TreeNode rightNode in right)
                        {
                            dp[start][end].Add(new(i, leftNode, rightNode));
                        }
                    }
                }
            }
        }

        return dp[1][n];
    }
}