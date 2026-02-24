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
    int ans = 0;
    public int SumRootToLeaf(TreeNode root)
    {
        DFS(root, 0);
        return ans;
    }

    void DFS(TreeNode root, int val)
    {
        if (root is null) return;
        val = (val << 1) | root.val;
        if (root.left == root.right)
        {
            ans += val;
            return;
        }
        DFS(root.left, val);
        DFS(root.right, val);
    }
}