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
    public IList<double> AverageOfLevels(TreeNode root)
    {
        IList<double> ans = [];
        if (root == null) return ans;
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int size = queue.Count;
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                sum += node.val;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            ans.Add(sum / size);
        }
        return ans;
    }
}