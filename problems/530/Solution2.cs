#if DEBUG
namespace Problems_530_2;
#endif

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
    private int min = int.MaxValue;
    private int? prev = null;

    public int GetMinimumDifference(TreeNode root)
    {
        if (root == null) return min;
        GetMinimumDifference(root.left);
        if (prev != null)
        {
            min = Math.Min(min, root.val - prev.Value);
        }
        prev = root.val;
        GetMinimumDifference(root.right);
        return min;
    }
}