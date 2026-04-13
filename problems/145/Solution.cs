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
    public IList<int> PostorderTraversal(TreeNode root)
    {
        IList<int> ans = [];
        void DFS(TreeNode root)
        {
            if (root is null)
                return;
            DFS(root.left);
            DFS(root.right);
            ans.Add(root.val);
        }
        DFS(root);
        return ans;
    }
}
