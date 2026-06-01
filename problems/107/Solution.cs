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
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        List<IList<int>> ans = [];
        if (root == null) return ans;
        Queue<TreeNode> q = [];
        q.Enqueue(root);
        while (q.Count > 0)
        {
            int s = q.Count;
            List<int> l = [];
            while (s-- > 0)
            {
                TreeNode cur = q.Dequeue();
                l.Add(cur.val);
                if (cur.left != null) q.Enqueue(cur.left);
                if (cur.right != null) q.Enqueue(cur.right);
            }
            ans.Add(l);
        }
        ans.Reverse();
        return ans;
    }
}
