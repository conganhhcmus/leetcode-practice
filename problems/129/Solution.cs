#if DEBUG
namespace Problems_129;
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
    public int SumNumbers(TreeNode root)
    {
        if (root == null) return 0;
        Queue<(TreeNode, int)> queue = [];
        queue.Enqueue((root, root.val));
        int ans = 0;
        while (queue.Count > 0)
        {
            var (node, val) = queue.Dequeue();
            if (node.left == null && node.right == null) ans += val;
            if (node.left != null) queue.Enqueue((node.left, val * 10 + node.left.val));
            if (node.right != null) queue.Enqueue((node.right, val * 10 + node.right.val));
        }
        return ans;
    }
}