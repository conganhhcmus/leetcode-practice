#if DEBUG
namespace Problems_94_2;
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
    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> ret = [];
        Inorder(root, ret);
        return ret;
    }

    void Inorder(TreeNode curr, IList<int> ret)
    {
        if (curr == null) return;
        Inorder(curr.left, ret);
        ret.Add(curr.val);
        Inorder(curr.right, ret);
    }
}