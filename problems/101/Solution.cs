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
    public bool IsSymmetric(TreeNode root)
    {
        if (root == null) return true;
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int size = queue.Count;
            List<int?> level = [];
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                if (node == null)
                {
                    level.Add(null);
                }
                else
                {
                    level.Add(node.val);
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            for (int i = 0; i < size / 2; i++)
            {
                if (level[i] != level[size - i - 1])
                {
                    return false;
                }
            }
        }

        return true;
    }
}