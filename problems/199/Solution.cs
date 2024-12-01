namespace Problem_199;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var root = TreeNodeHelper.CreateTreeFromArray([1, 2, 3, null, 5, null, 4]);
        var solution = new Solution();
        var res = solution.RightSideView(root);
        Console.WriteLine($"[{string.Join(",", res)}]");
    }
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> ans = [];
        Queue<TreeNode> queue = [];
        Queue<TreeNode> queue2 = [];
        if (root is null) return ans;
        queue.Enqueue(root);
        ans.Add(root.val);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (currentNode.left is not null)
            {
                queue2.Enqueue(currentNode.left);
            }

            if (currentNode.right is not null)
            {
                queue2.Enqueue(currentNode.right);
            }

            if (queue.Count == 0 && queue2.Count > 0)
            {
                int addValue = queue2.Peek().val;
                while (queue2.Count > 0)
                {
                    var tmpNode = queue2.Dequeue();
                    queue.Enqueue(tmpNode);
                    addValue = tmpNode.val;
                }
                ans.Add(addValue);
            }
        }
        return ans;
    }
}