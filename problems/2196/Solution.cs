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
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        Dictionary<int, TreeNode> map = [];
        HashSet<int> childrens = [];
        foreach (int[] d in descriptions)
        {
            int parent = d[0];
            int child = d[1];
            bool isLeft = d[2] == 1;
            childrens.Add(child);
            if (!map.ContainsKey(parent)) map[parent] = new TreeNode(parent);
            if (!map.ContainsKey(child)) map[child] = new TreeNode(child);
            if (isLeft) map[parent].left = map[child];
            else map[parent].right = map[child];
        }
        foreach (int[] d in descriptions)
        {
            if (!childrens.Contains(d[0])) return map[d[0]];
        }
        return null;
    }
}
