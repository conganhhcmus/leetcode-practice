#if DEBUG
namespace Problems_515;
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
    public IList<int> LargestValues(TreeNode root)
    {
        if (root is null) return [];
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        IList<int> ans = [];
        while (queue.Count > 0)
        {
            int size = queue.Count;
            int max = int.MinValue;
            for (int i = 0; i < size; i++)
            {
                TreeNode curr = queue.Dequeue();
                if (curr.val > max) max = curr.val;
                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }
            ans.Add(max);
        }

        return ans;
    }
}