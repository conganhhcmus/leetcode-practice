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
    List<int> values = [];
    Dictionary<int, TreeNode> map = [];

    public void RecoverTree(TreeNode root)
    {
        InOrder(root);
        List<int> tmp = [];
        foreach (int val in values)
        {
            tmp.Add(val);
        }
        tmp.Sort();
        for (int i = 0; i < tmp.Count; i++)
        {
            if (tmp[i] != values[i])
            {
                (map[tmp[i]].val, map[values[i]].val) = (map[values[i]].val, map[tmp[i]].val);
                return;
            }
        }
    }

    void InOrder(TreeNode node)
    {
        if (node is null) return;
        InOrder(node.left);
        values.Add(node.val);
        map[node.val] = node;
        InOrder(node.right);
    }
}