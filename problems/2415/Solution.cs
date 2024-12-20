#if DEBUG
namespace Problems_2415;
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
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        Traverse(root.left, root.right, true);
        return root;
    }

    public static void Traverse(TreeNode node1, TreeNode node2, bool isOdd)
    {
        if (node1 == null || node2 == null) return;

        if (isOdd)
        {
            (node2.val, node1.val) = (node1.val, node2.val);
        }

        Traverse(node1.left, node2.right, !isOdd);
        Traverse(node1.right, node2.left, !isOdd);
    }
}