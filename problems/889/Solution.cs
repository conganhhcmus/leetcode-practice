#if DEBUG
namespace Problems_889;
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
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        if (preorder.Length != postorder.Length || preorder.Length == 0) return null;
        TreeNode root = new TreeNode(preorder[0]);
        if (preorder.Length == 1) return root;
        int leftSub = Array.IndexOf(postorder, preorder[1]);

        root.left = ConstructFromPrePost(preorder[1..(leftSub + 2)], postorder[..(leftSub + 1)]);
        root.right = ConstructFromPrePost(preorder[(leftSub + 2)..], postorder[(leftSub + 1)..^1]);
        return root;
    }
}