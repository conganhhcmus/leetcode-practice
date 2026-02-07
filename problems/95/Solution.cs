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
        // n = 8
        // O(2^8)
        if (n <= 0) return [];
        return Generate(1, n, []);
    }

    IList<TreeNode> Generate(int start, int end, Dictionary<(int, int), IList<TreeNode>> memo)
    {
        if (start > end) return [null];
        var key = (start, end);
        if (memo.TryGetValue(key, out IList<TreeNode> cached)) return cached;
        IList<TreeNode> ret = [];
        for (int i = start; i <= end; i++)
        {
            IList<TreeNode> left = Generate(start, i - 1, memo);
            IList<TreeNode> right = Generate(i + 1, end, memo);
            foreach (TreeNode leftNode in left)
            {
                foreach (TreeNode rightNode in right)
                {
                    ret.Add(new(i, leftNode, rightNode));
                }
            }
        }

        memo[key] = ret;
        return ret;
    }
}