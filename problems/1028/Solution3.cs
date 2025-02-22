#if DEBUG
namespace Problems_1028_3;
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
    public TreeNode RecoverFromPreorder(string traversal)
    {
        Stack<TreeNode> stack = [];
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
            TreeNode child = new TreeNode(value);
            while (stack.Count > depth) stack.Pop();
            if (stack.TryPeek(out TreeNode parent))
            {
                if (parent.left == null) parent.left = child;
                else parent.right = child;
            }
            stack.Push(child);
        }

        return stack.LastOrDefault();
    }
}