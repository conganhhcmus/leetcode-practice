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
    public int SumNumbers(TreeNode root)
    {
        if (root == null) return 0;
        return DFS(root, 0);
    }

    private int DFS(TreeNode root, int curr)
    {
        if (root == null) return 0;
        curr = curr * 10 + root.val;
        if (root.left == null && root.right == null) return curr;
        return DFS(root.left, curr) + DFS(root.right, curr);
    }
}