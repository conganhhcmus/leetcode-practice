namespace Helpers.TreeNode;
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

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
}