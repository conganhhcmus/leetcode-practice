namespace Problem_1372;

using Helpers.TreeNode;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([6, 9, 7, 3, null, 2, 8, 5, 8, 9, 7, 3, 9, 9, 4, 2, 10, null, 5, 4, 3, 10, 10, 9, 4, 1, 2, null, null, 6, 5, null, null, null, null, 9, null, 9, 6, 5, null, 5, null, null, 7, 7, 4, null, 1, null, null, 3, 7, null, 9, null, null, null, null, null, null, null, null, 9, 9, null, null, null, 7, null, null, null, null, null, null, null, null, null, 6, 8, 7, null, null, null, 3, 10, null, null, null, null, null, 1, null, 1, 2]);
        var solution = new Solution();
        Console.WriteLine(solution.LongestZigZag(root));
    }
    public int LongestZigZag(TreeNode root)
    {
        var maxLength = 0;
        void DFS(TreeNode node, bool direction, int currentLength) // false: left, true: right
        {
            if (node is null) return;
            maxLength = Math.Max(maxLength, currentLength);

            DFS(node.left, false, direction ? currentLength + 1 : 1);
            DFS(node.right, true, !direction ? currentLength + 1 : 1);
        }
        DFS(root.left, false, 1);
        DFS(root.right, true, 1);
        return maxLength;
    }
}