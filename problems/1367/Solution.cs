namespace Problem_1367;

using Helpers.TreeNode;
using Helpers.ListNode;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();

        var head = ListNodeHelper.CreateListFromArray([10, 10, 4, 9, 9, 4, 2, 2, 9, 9, 5]);

        var root = TreeNodeHelper.CreateTreeFromArray([10, 10, 9, 4, 7, 6, 10, 10, 9, 6, 4, 8, 8, 9, 2, null, 2, null, 9, null, null, null, null, null, 9, 1, 7, null, null, null, null, 7, 4, 4, 6, null, null, 6, null, null, null, null, null, 9, 6, null, 2, 4, 8, null, 5, 2, null, null, null, 2, null, null, null, null, 3, 8, 2, null, 5, 4, 9, null, null, 6, null, 1, 3, null, null, 8, 9, null, 9, null, null, null, 5, null, null, 1, 1, null, null, 5, null, null, null, null, null, null, null, 7]);

        Console.WriteLine(solution.IsSubPath(head, root));
    }

    public bool IsSubPath(ListNode head, TreeNode root)
    {
        var res = false;
        List<int> headList = [];
        while (head != null)
        {
            headList.Add(head.val);
            head = head.next;
        }

        var rootList = BFS(root).Where(x => x.val == headList[0]).ToList();

        foreach (var node in rootList)
        {
            if (res) return res;
            DFS(node, [], headList, ref res);
        }
        return res;
    }

    private List<TreeNode> BFS(TreeNode root)
    {
        if (root is null) return [];

        var res = new List<TreeNode>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            res.Add(node);

            if (node.left is not null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right is not null)
            {
                queue.Enqueue(node.right);
            }
        }

        return res;
    }

    private void DFS(TreeNode root, List<int> stackList, List<int> headList, ref bool res)
    {
        if (root is null || res) return;
        stackList.Add(root.val);
        // check if stack is sub path of head list
        res = CheckSubPathMatch(stackList, headList);
        DFS(root.left, stackList, headList, ref res);
        DFS(root.right, stackList, headList, ref res);
        stackList.RemoveAt(stackList.Count - 1);
    }

    private bool CheckSubPathMatch(List<int> stackList, List<int> headList)
    {
        if (stackList.Count < headList.Count) return false;

        for (int i = 0; i < headList.Count; i++)
        {
            if (stackList.ElementAt(i) != headList[i]) return false;
        }
        return true;
    }
}