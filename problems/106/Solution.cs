#if DEBUG
namespace Problems_106;
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
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        var root = new TreeNode(postorder[^1]);
        int n = postorder.Length;
        if (n == 1) return root;
        var rootIndex = Array.IndexOf(inorder, root.val);
        if (rootIndex > 0)
        {
            root.left = BuildTree(inorder[..rootIndex], postorder[..rootIndex]);
        }
        if (rootIndex < n - 1)
        {
            root.right = BuildTree(inorder[(rootIndex + 1)..], postorder[rootIndex..^1]);
        }
        return root;
    }
}