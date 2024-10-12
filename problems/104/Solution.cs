namespace Problem_104;
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
public class Solution
{
    public static void Execute()
    {
        int?[] rootArr = [3, 9, 20, null, null, 15, 7];

        var tmpTree = new TreeNode[rootArr.Length];
        for (int i = 0; i < rootArr.Length; i++)
        {
            if (rootArr[i] is not null)
            {
                tmpTree[i] = new TreeNode(rootArr[i].Value);
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

        var root = tmpTree[0];

        var solution = new Solution();
        Console.WriteLine(solution.MaxDepth(root));
    }
    public int MaxDepth(TreeNode root)
    {
        return DFS(root, 0);
    }

    private int DFS(TreeNode node, int length)
    {
        if (node is null) return length;
        return Math.Max(DFS(node.left, length + 1), DFS(node.right, length + 1));
    }
}