namespace Helpers;

public static class TreeNodeHelper
{
    public static TreeNode CreateTreeFromArray(int?[] array)
    {
        if (array.Length == 0) return null;
        if (array.Length == 1) return new TreeNode(array[0].Value);
        if (array.Length == 2) return new TreeNode(array[0].Value, new TreeNode(array[1].Value), null);

        var tmpTree = new TreeNode[array.Length];
        for (int i = 0; i < array.Length; i++)
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
            var currentNode = queue.Dequeue();
            int?[] tmp = new int?[2];
            if (currentNode.left is not null)
            {
                queue.Enqueue(currentNode.left);
                tmp[0] = currentNode.left.val;
            }
            if (currentNode.right is not null)
            {
                queue.Enqueue(currentNode.right);
                tmp[1] = currentNode.right.val;
            }
            if (tmp[0] is not null || tmp[1] is not null)
            {
                result.AddRange(tmp);
            }
        }
        return JsonConvert.SerializeObject(result);
    }
}