namespace Problem_236;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([1, 2]);
        var p = root; //1
        var q = root.left; //2
        var solution = new Solution();
        var res = solution.LowestCommonAncestor(root, p, q);
        Console.WriteLine(res.val);
    }
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root is null) return null;
        if (root == p || root == q) return root;

        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);

        if (left is null) return right;
        if (right is null) return left;
        return root;
    }
}