#if DEBUG
namespace Problems_230;
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
    public int KthSmallest(TreeNode root, int k)
    {
        int ans = int.MaxValue;
        InorderTraversal(root, ref ans, ref k);
        return ans;
    }

    private void InorderTraversal(TreeNode node, ref int ans, ref int k)
    {
        if (node == null) return;
        InorderTraversal(node.left, ref ans, ref k);
        if (k == 0) return;
        k--;
        ans = node.val;
        InorderTraversal(node.right, ref ans, ref k);
    }
}