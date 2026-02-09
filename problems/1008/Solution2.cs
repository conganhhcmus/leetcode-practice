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
    int i = 0;
    public TreeNode BstFromPreorder(int[] preorder)
    {
        return Build(preorder, int.MaxValue);
    }

    TreeNode Build(int[] preorder, int val)
    {
        if (i == preorder.Length || preorder[i] > val) return null;
        TreeNode node = new(preorder[i]);
        i++;
        node.left = Build(preorder, node.val);
        node.right = Build(preorder, val);

        return node;
    }
}