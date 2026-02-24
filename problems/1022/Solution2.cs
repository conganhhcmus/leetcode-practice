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
    public int SumRootToLeaf(TreeNode root)
    {
        Queue<(TreeNode, int)> queue = [];
        int ans = 0;
        queue.Enqueue((root, 0));
        while (queue.Count > 0)
        {
            var (node, val) = queue.Dequeue();
            val = (val << 1) | node.val;
            if (node.left == node.right)
            {
                ans += val;
                continue;
            }
            if (node.left is not null)
            {
                queue.Enqueue((node.left, val));
            }
            if (node.right is not null)
            {
                queue.Enqueue((node.right, val));
            }
        }

        return ans;
    }
}