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
    public TreeNode BalanceBST(TreeNode root)
    {
        List<int> values = [];
        InOrder(root, values);
        return Build(0, values.Count - 1, values);
    }

    TreeNode Build(int st, int ed, List<int> values)
    {
        if (st > ed) return null;
        int mid = st + (ed - st) / 2;
        TreeNode root = new(values[mid])
        {
            left = Build(st, mid - 1, values),
            right = Build(mid + 1, ed, values)
        };
        return root;
    }

    void InOrder(TreeNode node, List<int> values)
    {
        if (node is null) return;
        InOrder(node.left, values);
        values.Add(node.val);
        InOrder(node.right, values);
    }
}