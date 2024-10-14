namespace Problem_437;

using Helpers.TreeNode;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([10, 5, -3, 3, 2, null, 11, 3, -2, null, 1]);
        var targetSum = 3;
        var solution = new Solution();
        Console.WriteLine(solution.PathSum(root, targetSum));
        Console.WriteLine(solution.PathSum2(root, targetSum));
    }
    public int PathSum(TreeNode root, int targetSum)
    {
        if (root is null) return 0;
        int ans = 0;
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var currRoot = queue.Dequeue();
            if (currRoot.left is not null) queue.Enqueue(currRoot.left);
            if (currRoot.right is not null) queue.Enqueue(currRoot.right);
            ans += DFS(currRoot, targetSum, 0);
        }
        return ans;
    }

    private int DFS(TreeNode node, int targetSum, long currentSum)
    {
        if (node is null) return 0;
        if (currentSum > targetSum) return 0;

        currentSum += node.val;
        int count = (targetSum == currentSum) ? 1 : 0;

        return count
            + DFS(node.left, targetSum, currentSum)
            + DFS(node.right, targetSum, currentSum);
    }

    public int PathSum2(TreeNode root, int targetSum)
    {
        var count = 0;
        var cache = new Dictionary<long, int>();
        cache[0] = 1;
        void dfs(TreeNode node, long sum)
        {
            if (node is null) return;
            sum += node.val;
            cache[sum] = cache.GetValueOrDefault(sum, 0) + 1;
            if (cache.TryGetValue(sum - targetSum, out int c)) count += c;
            dfs(node.left, sum);
            dfs(node.right, sum);
            cache[sum]--; // backtrack
        }

        dfs(root, 0);
        return count;
    }
}