namespace Problem_2458;

public class Solution
{
    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        int[] levelArr = new int[100_001];
        int[] depth = new int[100_001];
        int[] max1 = new int[100_001];
        int[] max2 = new int[100_001];

        int DFS(TreeNode root, int level)
        {
            if (root is null) return 0;
            levelArr[root.val] = level;
            depth[root.val] = 1 + Math.Max(DFS(root.right, level + 1), DFS(root.left, level + 1));

            if (max1[level] < depth[root.val])
            {
                max2[level] = max1[level];
                max1[level] = depth[root.val];
            }
            else if (max2[level] < depth[root.val])
            {
                max2[level] = depth[root.val];
            }

            return depth[root.val];
        }

        DFS(root, 0);

        int[] ans = new int[queries.Length];
        for (int i = 0; i < ans.Length; i++)
        {
            int level = levelArr[queries[i]];
            ans[i] = (max1[level] == depth[queries[i]] ? max2[level] : max1[level]) + level - 1;
        }

        return ans;
    }
}