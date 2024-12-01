namespace Problem_450;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([5, 3, 6, 2, 4, null, 7]);
        var key = 3;
        var solution = new Solution();
        Console.WriteLine($"[{string.Join(",", TreeNodeHelper.BFSTraversal(root))}]");
        var newRoot = solution.DeleteNode(root, key);
        Console.WriteLine($"[{string.Join(",", TreeNodeHelper.BFSTraversal(newRoot))}]");
    }
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root is null) return null;
        if (root.val > key)
        {
            root.left = DeleteNode(root.left, key);
        }
        else if (root.val < key)
        {
            root.right = DeleteNode(root.right, key);
        }
        else
        {
            if (root.left is null)
            {
                return root.right;
            }

            if (root.right is null)
            {
                return root.left;
            }

            TreeNode curr = root.right;
            while (curr.left is not null)
            {
                curr = curr.left;
            }
            root.val = curr.val;
            root.right = DeleteNode(root.right, curr.val);
        }
        return root;
    }
}