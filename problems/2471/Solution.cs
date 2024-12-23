#if DEBUG
namespace Problems_2471;
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
    public int MinimumOperations(TreeNode root)
    {
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        int ans = 0;
        while (queue.Count > 0)
        {
            List<int> source = [];
            int size = queue.Count;
            while (size-- > 0)
            {
                TreeNode curr = queue.Dequeue();
                source.Add(curr.val);
                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }
            List<int> target = [.. source];
            target.Sort();
            Dictionary<int, int> map = [];
            int swaps = 0;
            for (int i = 0; i < source.Count; i++) map[source[i]] = i;
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] != target[i])
                {
                    swaps++;
                    map[source[i]] = map[target[i]];
                    source[map[target[i]]] = source[i];
                }
            }

            ans += swaps;
        }
        return ans;
    }
}