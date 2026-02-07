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
    public TreeNode RecoverFromPreorder(string traversal)
    {
        int depth = 0;
        while (traversal[depth] == '-') depth++;
        int nextStart = traversal.IndexOf('-', depth + 1);
        if (nextStart == -1) nextStart = traversal.Length;
        int value = int.Parse(traversal[depth..nextStart]);
        TreeNode root = new TreeNode(value);
        if (nextStart == traversal.Length) return root;

        traversal = traversal[nextStart..];
        int count = 0, idx = traversal.Length;
        for (int i = depth + 1; i < traversal.Length; i++)
        {
            if (traversal[i] == '-') count++;
            else
            {
                if (count == depth + 1)
                {
                    idx = i - depth - 1;
                    break;
                }
                count = 0;
            }
        }

        root.left = RecoverFromPreorder(traversal[..idx]);
        if (idx != traversal.Length) root.right = RecoverFromPreorder(traversal[idx..]);
        return root;
    }
}