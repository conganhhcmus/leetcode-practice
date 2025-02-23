#if DEBUG
namespace Problems_889_3;
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
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        TreeNode root = new TreeNode(preorder[0]);
        Stack<TreeNode> stack = [];
        stack.Push(root);
        var postOrderIndex = 0;
        for (int i = 1; i < preorder.Length; i++)
        {
            while (stack.Count > 0 && stack.Peek().val == postorder[postOrderIndex]) // stack.Peek() is leaf node
            {
                stack.Pop();
                postOrderIndex++;
            }
            TreeNode node = new(preorder[i]);
            TreeNode parent = stack.Peek();
            if (parent.left == null) parent.left = node;
            else parent.right = node;
            stack.Push(node);
        }
        return root;
    }
}