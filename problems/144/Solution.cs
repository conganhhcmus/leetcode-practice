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
    public IList<int> PreorderTraversal(TreeNode root)
    {
        IList<int> ans = [];
        void DFS(TreeNode root)
        {
            if (root is null)
                return;
            ans.Add(root.val);
            DFS(root.left);
            DFS(root.right);
        }
        DFS(root);
        return ans;
    }
}
