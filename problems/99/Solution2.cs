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
    TreeNode p1 = null;
    TreeNode p2 = null;
    TreeNode prev = null;

    public void RecoverTree(TreeNode root)
    {
        InOrder(root);
        (p1.val, p2.val) = (p2.val, p1.val);
    }

    void InOrder(TreeNode node)
    {
        if (node is null) return;
        InOrder(node.left);
        if (p1 == null && prev is not null && prev.val >= node.val)
        {
            p1 = prev;
        }

        if (p1 != null && prev is not null && prev.val >= node.val)
        {
            p2 = node;
        }

        prev = node;
        InOrder(node.right);
    }
}