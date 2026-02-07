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
        LinkedList<TreeNode> dequeue = [];
        dequeue.AddFirst(root);
        bool reverse = false;
        while (dequeue.Count > 0)
        {
            int size = dequeue.Count;
            List<int> level = [];
            for (int i = 0; i < size; i++)
            {
                if (!reverse)
                {
                    TreeNode node = dequeue.First.Value;
                    dequeue.RemoveFirst();
                    level.Add(node.val);
                    if (node.left != null) dequeue.AddLast(node.left);
                    if (node.right != null) dequeue.AddLast(node.right);
                }
                else
                {
                    TreeNode node = dequeue.Last.Value;
                    dequeue.RemoveLast();
                    level.Add(node.val);
                    if (node.right != null) dequeue.AddFirst(node.right);
                    if (node.left != null) dequeue.AddFirst(node.left);
                }
            }
            ans.Add(level);
            reverse = !reverse;
        }

        return ans;
    }
}