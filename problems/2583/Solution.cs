public class Solution
{
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