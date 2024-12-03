namespace Problem_1367;

public class Solution
{
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