#if DEBUG
namespace Problems_1028_2;
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
    public TreeNode RecoverFromPreorder(string traversal)
    {
        int start = 0;
        return Helper(traversal, 0, ref start);
    }

    private TreeNode Helper(string traversal, int depth, ref int start)
    {
        int n = traversal.Length;
        if (start >= n) return null;
        int dashCount = 0;
        for (int i = start; i < n; i++)
        {
            if (traversal[i] != '-') break;
            dashCount++;
        }

        if (dashCount != depth) return null;
        int value = 0;
        start += dashCount;
        for (; start < n; start++)
        {
            if (!char.IsDigit(traversal[start])) break;
            value = value * 10 + (traversal[start] - '0');
        }

        TreeNode node = new TreeNode(value);
        node.left = Helper(traversal, depth + 1, ref start);
        node.right = Helper(traversal, depth + 1, ref start);
        return node;
    }
}