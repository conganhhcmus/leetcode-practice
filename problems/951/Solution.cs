namespace Problem_951;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var root1 = TreeNodeHelper.CreateTreeFromArray([1, 2, 3]);
        var root2 = TreeNodeHelper.CreateTreeFromArray([1, 2, null, 3]);
        var solution = new Solution();
        Console.WriteLine(solution.FlipEquiv(root1, root2));
    }
    public bool FlipEquiv(TreeNode root1, TreeNode root2)
    {
        if (root1 is null || root2 is null) return root1 == root2;

        Queue<TreeNode> queue = [];
        Queue<TreeNode> queue2 = [];
        queue.Enqueue(root1);
        queue2.Enqueue(root2);
        while (queue.Count > 0 && queue2.Count > 0)
        {
            int length1 = queue.Count;
            int length2 = queue2.Count;
            if (length1 != length2) return false;

            for (int i = 0; i < length1; i++)
            {
                var node1 = queue.Dequeue();
                var node2 = queue2.Dequeue();
                if (node1.val != node2.val) return false;

                List<TreeNode> children1 = [];
                List<TreeNode> children2 = [];
                if (node1.left is not null) children1.Add(node1.left);
                if (node1.right is not null) children1.Add(node1.right);

                if (node2.left is not null) children2.Add(node2.left);
                if (node2.right is not null) children2.Add(node2.right);

                if (children1.Count != children2.Count) return false;

                children1.Sort((a, b) => a.val - b.val);
                children2.Sort((a, b) => a.val - b.val);

                for (int j = 0; j < 2; j++)
                {
                    queue.Enqueue(children1[j]);
                    queue.Enqueue(children2[j]);
                }
            }
        }

        return queue.Count == queue2.Count;
    }
}