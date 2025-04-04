#if DEBUG
namespace Problems_1123_2;
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
    public TreeNode LcaDeepestLeaves(TreeNode root)
    {
        return FindLca(root).node;
    }

    (TreeNode node, int depth) FindLca(TreeNode root)
    {
        if (root == null) return (null, 0);
        var left = FindLca(root.left);
        var right = FindLca(root.right);
        if (left.depth > right.depth) return (left.node, left.depth + 1);
        if (left.depth < right.depth) return (right.node, right.depth + 1);
        return (root, left.depth + 1);
    }
}