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
    public int KthSmallest(TreeNode root, int k)
    {
        // Morris Traversal
        var curr = root;
        while (curr != null)
        {
            if (curr.left == null)
            {
                if (--k == 0) return curr.val;
                curr = curr.right;
            }
            else
            {
                var prev = curr.left;
                while (prev.right != null && prev.right != curr)
                {
                    prev = prev.right;
                }

                if (prev.right == null)
                {
                    prev.right = curr;
                    curr = curr.left;
                }
                else
                {
                    prev.right = null;
                    if (--k == 0) return curr.val;
                    curr = curr.right;
                }
            }
        }

        return int.MaxValue;
    }
}