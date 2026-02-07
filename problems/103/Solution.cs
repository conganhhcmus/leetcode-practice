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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        IList<IList<int>> ans = [];
        if (root == null) return ans;
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        bool reverse = false;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            List<int> level = [];
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                level.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            if (reverse) level.Reverse();
            ans.Add(level);
            reverse = !reverse;
        }

        return ans;
    }
}