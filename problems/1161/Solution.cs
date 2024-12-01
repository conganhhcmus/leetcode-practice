namespace Problem_1161;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([1, 7, 0, 7, -8, null, null]);
        var solution = new Solution();
        Console.WriteLine(solution.MaxLevelSum(root));
    }
    public int MaxLevelSum(TreeNode root)
    {
        long maxSum = long.MinValue;
        int level = 0;
        int ans = 0;
        if (root is null) return ans;

        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            long sum = 0;
            var length = queue.Count;
            level++;

            for (int i = 0; i < length; i++)
            {
                var node = queue.Dequeue();
                sum += node.val;
                if (node.left is not null) queue.Enqueue(node.left);
                if (node.right is not null) queue.Enqueue(node.right);
            }

            if (sum > maxSum)
            {
                maxSum = sum;
                ans = level;
            }
        }

        return ans;
    }
}