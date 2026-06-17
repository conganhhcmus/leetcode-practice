public class Solution
{
    public int[] MaxSubgraphScore(int n, int[][] edges, int[] good)
    {
        int[] w = new int[n];
        for (int i = 0; i < n; i++)
        {
            w[i] = good[i] == 1 ? 1 : -1;
        }
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1];
            g[u].Add(v);
            g[v].Add(u);
        }
        int[] ans = new int[n];
        int[] dp = new int[n];
        Dfs1(0, -1);
        ans[0] = dp[0];
        Dfs2(0, -1);
        return ans;

        void Dfs1(int u, int p)
        {
            dp[u] = w[u];
            foreach (int v in g[u])
            {
                if (v == p) continue;
                Dfs1(v, u);
                dp[u] += Math.Max(0, dp[v]);
            }
        }

        void Dfs2(int u, int p)
        {
            foreach (int v in g[u])
            {
                if (v == p) continue;
                ans[v] = dp[v] + Math.Max(0, ans[u] - Math.Max(0, dp[v]));
                Dfs2(v, u);
            }
        }
    }
}
