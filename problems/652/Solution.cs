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
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        DFS(root);
        return ret;
    }

    IList<TreeNode> ret = [];
    Dictionary<string, int> map = [];
    string DFS(TreeNode root)
    {
        if (root is null) return "#";
        string path = root.val + "," + DFS(root.left) + "," + DFS(root.right);
        map[path] = map.GetValueOrDefault(path, 0) + 1;
        if (map[path] == 2) ret.Add(root);
        return path;
    }
}