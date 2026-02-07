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
public class BSTIterator
{
    TreeNode _root;

    public BSTIterator(TreeNode root)
    {
        _root = root;
    }

    public int Next()
    {
        TreeNode curr = _root, prev = null;
        while (curr.left != null)
        {
            prev = curr;
            curr = curr.left;
        }

        int val = curr.val;
        TreeNode right = curr.right;
        if (prev == null) _root = right;
        else prev.left = right;

        return val;
    }

    public bool HasNext()
    {
        return _root is not null;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */

public class Solution
{
    public List<dynamic> Execute(string[] actions, int?[][][] values)
    {
        List<dynamic> result = [];
        BSTIterator bst = new(null);
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "BSTIterator":
                    bst = new BSTIterator(TreeNodeHelper.CreateTreeFromArray(values[i][0]));
                    result.Add(null);
                    break;
                case "next":
                    result.Add(bst.Next());
                    break;
                case "hasNext":
                    result.Add(bst.HasNext());
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}