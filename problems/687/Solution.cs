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
    public int LongestUnivaluePath(TreeNode root)
    {
        var (ans, _) = Longest(root);
        return Math.Max(0, ans - 1);
    }

    (int a1, int a2) Longest(TreeNode root)
    {
        if (root is null) return (0, 0);
        int a = 1, a2 = 1;
        var (l1, l2) = Longest(root.left);
        var (r1, r2) = Longest(root.right);

        if (root.left is not null && root.left.val == root.val)
        {
            a2 += l2;
            a = Math.Max(a, 1 + l2);
        }
        if (root.right is not null && root.right.val == root.val)
        {
            a2 += r2;
            a = Math.Max(a, 1 + r2);
        }

        int a1 = Math.Max(a2, Math.Max(l1, r1));
        return (a1, a);
    }
}
