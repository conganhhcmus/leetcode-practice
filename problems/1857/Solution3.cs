public class Solution
{
    public int LargestPathValue(string colors, int[][] edges)
    {
        int n = colors.Length;
        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = [];
        }
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
        }
        int[] mark = new int[n];
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[26];
        }
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            int ret = DFS(i, adj, colors, dp, mark);
            if (ret == -1) return -1;
            max = Math.Max(max, ret);
        }
        return max;
    }

    int DFS(int u, List<int>[] adj, string colors, int[][] count, int[] mark)
    {
        if (mark[u] == 1) return -1;
        int idx = colors[u] - 'a';
        if (mark[u] == 2) return count[u][idx];

        mark[u] = 1;
        foreach (int v in adj[u])
        {
            int ret = DFS(v, adj, colors, count, mark);
            if (ret == -1) return -1;
            for (int i = 0; i < 26; i++)
            {
                count[u][i] = Math.Max(count[u][i], count[v][i]);
            }
        }

        count[u][idx]++;
        mark[u] = 2;
        return count[u][idx];
    }
}