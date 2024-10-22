namespace Problem_2583;

using Helpers.TreeNode;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([5, 8, 9, 2, 1, 3, 7, 4, 6]);
        var k = 2;
        var solution = new Solution();
        Console.WriteLine(solution.KthLargestLevelSum(root, k));
    }
    public long KthLargestLevelSum(TreeNode root, int k)
    {
        if (root is null) return -1;
        Queue<TreeNode> queue = [];
        List<long> sumLevel = [];
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int length = queue.Count;
            long sum = 0;
            for (int i = 0; i < length; i++)
            {
                var node = queue.Dequeue();
                sum += node.val;
                if (node.left is not null) queue.Enqueue(node.left);
                if (node.right is not null) queue.Enqueue(node.right);
            }
            sumLevel.Add(sum);
        }

        if (k > sumLevel.Count) return -1;
        sumLevel.Sort((a, b) => b.CompareTo(a));
        return sumLevel[k - 1];
    }
}