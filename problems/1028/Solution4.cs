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
    public TreeNode RecoverFromPreorder(string traversal)
    {
        List<TreeNode> levels = [];
        int idx = 0;
        int n = traversal.Length;
        while (idx < n)
        {
            // count dash
            int depth = 0;
            while (idx < n && traversal[idx] == '-')
            {
                depth++;
                idx++;
            }
            int value = 0;
            while (idx < n && traversal[idx] != '-')
            {
                value = value * 10 + (traversal[idx] - '0');
                idx++;
            }
            TreeNode node = new TreeNode(value);

            if (depth >= levels.Count) levels.Add(node);
            else levels[depth] = node;

            if (depth > 0)
            {
                TreeNode parent = levels[depth - 1];
                if (parent.left == null) parent.left = node;
                else parent.right = node;
            }
        }

        return levels[0];
    }
}