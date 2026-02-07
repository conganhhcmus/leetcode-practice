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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        TreeNode root = new(preorder[0]);
        int n = preorder.Length;
        if (n == 1) return root;
        int rootIndex = Array.IndexOf(inorder, preorder[0]);
        if (rootIndex > 0)
        {
            root.left = BuildTree(preorder[1..(rootIndex + 1)], inorder[0..rootIndex]);
        }
        if (rootIndex < n - 1)
        {
            root.right = BuildTree(preorder[(rootIndex + 1)..], inorder[(rootIndex + 1)..]);
        }

        return root;
    }
}