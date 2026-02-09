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
    public TreeNode BstFromPreorder(int[] preorder)
    {
        TreeNode root = null;

        foreach (int val in preorder)
        {
            root = Insert(root, val);
        }
        return root;
    }

    TreeNode Insert(TreeNode node, int val)
    {
        if (node is null)
        {
            return new(val);
        }

        if (node.val < val)
        {
            node.right = Insert(node.right, val);
        }
        else if (node.val > val)
        {
            node.left = Insert(node.left, val);
        }
        return node;
    }
}