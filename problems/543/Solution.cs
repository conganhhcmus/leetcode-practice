#if DEBUG
namespace Problems_543;
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
    int ret = 0;
    public int DiameterOfBinaryTree(TreeNode root)
    {
        MaxDepth(root);
        return ret;
    }

    int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        int leftDepth = MaxDepth(root.left);
        int rightDepth = MaxDepth(root.right);
        ret = Math.Max(ret, leftDepth + rightDepth);
        return Math.Max(leftDepth, rightDepth) + 1;
    }
}