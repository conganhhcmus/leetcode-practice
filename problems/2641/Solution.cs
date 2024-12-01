namespace Problem_2641;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([5, 4, 9, 1, 10, null, 7]);
        var solution = new Solution();
        var newRoot = solution.ReplaceValueInTree(root);
        Console.WriteLine($"{string.Join(",", TreeNodeHelper.BFSTraversal(newRoot))}");
    }
    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        if (root is null) return null;

        Queue<TreeNode> queue = [];
        Dictionary<int, int> dp = [];
        queue.Enqueue(root);
        int level = 0;
        while (queue.Count > 0)
        {
            int length = queue.Count;
            level++;
            for (int i = 0; i < length; i++)
            {
                var node = queue.Dequeue();
                dp[level] = dp.GetValueOrDefault(level, 0) + node.val;
                if (node.left is not null) queue.Enqueue(node.left);
                if (node.right is not null) queue.Enqueue(node.right);
            }
        }

        queue.Enqueue(root);
        root.val = 0;
        level = 0;
        while (queue.Count > 0)
        {
            int length = queue.Count;
            level++;
            for (int i = 0; i < length; i++)
            {
                var node = queue.Dequeue();
                int sum = 0;
                if (node.left is not null)
                {
                    queue.Enqueue(node.left);
                    sum += node.left.val;
                }
                if (node.right is not null)
                {
                    queue.Enqueue(node.right);
                    sum += node.right.val;
                }

                if (node.left is not null)
                {
                    node.left.val = dp[level + 1] - sum;
                }
                if (node.right is not null)
                {
                    node.right.val = dp[level + 1] - sum;
                }
            }
        }

        return root;
    }
}