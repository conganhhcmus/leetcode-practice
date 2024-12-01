namespace Helpers;

using Structures;

public static class TreeNodeHelper
{
    public static TreeNode CreateTreeFromArray(int?[] array)
    {
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

    public static int[] BFSTraversal(TreeNode root)
    {
        if (root is null) return [];
        List<int> result = [];
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            result.Add(currentNode.val);
            if (currentNode.right != null) queue.Enqueue(currentNode.right);
            if (currentNode.left != null) queue.Enqueue(currentNode.left);
        }
        return [.. result];
    }
}