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
    public int MinDiffInBST(TreeNode root)
    {
        if (root == null) return int.MaxValue;
        int min = GetMin(root.right);
        int max = GetMax(root.left);
        int diff = Math.Min(min - root.val, root.val - max);
        diff = Math.Min(diff, MinDiffInBST(root.left));
        diff = Math.Min(diff, MinDiffInBST(root.right));
        return diff;
    }

    public int GetMin(TreeNode root)
    {
        if (root == null) return int.MaxValue / 2;
        while (root.left != null)
        {
            root = root.left;
        }

        return root.val;
    }

    private int GetMax(TreeNode root)
    {
        if (root == null) return int.MinValue / 2;
        while (root.right != null)
        {
            root = root.right;
        }
        return root.val;
    }
}