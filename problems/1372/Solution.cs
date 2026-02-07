public class Solution
{
    public int LongestZigZag(TreeNode root)
    {
        var maxLength = 0;
        void DFS(TreeNode node, bool direction, int currentLength) // false: left, true: right
        {
            if (node is null) return;
            maxLength = Math.Max(maxLength, currentLength);

            DFS(node.left, false, direction ? currentLength + 1 : 1);
            DFS(node.right, true, !direction ? currentLength + 1 : 1);
        }
        DFS(root.left, false, 1);
        DFS(root.right, true, 1);
        return maxLength;
    }
}