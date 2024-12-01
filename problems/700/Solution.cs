namespace Problem_700;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([4, 2, 7, 1, 3]);
        var target = 2;
        var solution = new Solution();
        var node = solution.SearchBST(root, target);
        Console.WriteLine(node.val);
    }
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root is null) return null;

        if (root.val == val) return root;
        if (root.val > val) return SearchBST(root.left, val);
        return SearchBST(root.right, val);
    }
}