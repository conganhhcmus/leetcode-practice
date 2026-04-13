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
    public int MinDepth(TreeNode root)
    {
        if (root is null)
            return 0;
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        int depth = 1;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode curr = queue.Dequeue();
                if (curr.left is null && curr.right is null)
                    return depth;
                if (curr.left is not null)
                    queue.Enqueue(curr.left);
                if (curr.right is not null)
                    queue.Enqueue(curr.right);
            }
            depth++;
        }
        return -1;
    }
}
