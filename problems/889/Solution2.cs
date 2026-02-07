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
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        int n = preorder.Length;
        int[] map = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            map[postorder[i]] = i;
        }
        return Helper(map, preorder, postorder, 0, n - 1, 0);
    }

    private TreeNode Helper(int[] map, int[] preorder, int[] postorder, int start, int end, int postStart)
    {
        if (start > end) return null;
        if (start == end) return new(preorder[start]);
        TreeNode root = new(preorder[start]);

        int leftNode = preorder[start + 1];
        int numOfNodeInLeft = map[leftNode] - postStart + 1;

        root.left = Helper(map, preorder, postorder, start + 1, start + numOfNodeInLeft, postStart);
        root.right = Helper(map, preorder, postorder, start + numOfNodeInLeft + 1, end, postStart + numOfNodeInLeft);

        return root;
    }
}