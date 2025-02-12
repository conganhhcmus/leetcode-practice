namespace Helpers;

public static class TreeNodeHelper
{
    public static TreeNode CreateTreeFromArray(int?[] array)
    {
        if (array.Length == 0) return null;
        int n = array.Length, h = 0;
        while ((1 << h) <= n) h++;
        var tmpTree = new TreeNode[(1 << h) - 1];
        for (int i = 0; i < n; i++)
        {
            if (array[i] is not null)
            {
                tmpTree[i] = new TreeNode(array[i].Value);
            }
        }

        var last = 0;
        for (int i = 0; i < tmpTree.Length && last + 2 < tmpTree.Length; i++)
        {
            if (tmpTree[i] is not null)
            {
                tmpTree[i].left = tmpTree[last + 1];
                tmpTree[i].right = tmpTree[last + 2];
                last += 2;
            }
        }

        return tmpTree[0];
    }

    public static string BFSTraversal(TreeNode root)
    {
        if (root is null) return "[]";
        List<int?> result = [];
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        result.Add(root.val);

        while (queue.Count > 0)
        {
            int size = queue.Count;
            int?[] tmp = new int?[2 * size];
            bool hasValue = false;

            for (int i = 0; i < size; i++)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.left is not null)
                {
                    queue.Enqueue(currentNode.left);
                    tmp[2 * i] = currentNode.left.val;
                    hasValue = true;
                }
                if (currentNode.right is not null)
                {
                    queue.Enqueue(currentNode.right);
                    tmp[2 * i + 1] = currentNode.right.val;
                    hasValue = true;
                }
            }

            if (hasValue)
            {
                result.AddRange(tmp);
            }
        }
        return JsonConvert.SerializeObject(result);
    }
}