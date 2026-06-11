public class Solution
{
    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        int n = edges.Length + 1;
        int MOD = 1_000_000_007;
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        foreach (int[] e in edges)
        {
            int u = e[0] - 1, v = e[1] - 1;
            g[u].Add(v);
            g[v].Add(u);
        }
        int MAX = 20;
        int[] log2 = new int[n];
        for (int i = 2; i < n; i++)
        {
            log2[i] = log2[i / 2] + 1;
        }
        int[] depth = new int[n];
        int[][] parent = new int[n][];
        for (int i = 0; i < n; i++)
        {
            parent[i] = new int[MAX];
        }
        DFS(0);
        int[] power2 = new int[n + 1];
        power2[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            power2[i] = power2[i - 1] * 2 % MOD;
        }

        int m = queries.Length;
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            int u = queries[i][0] - 1, v = queries[i][1] - 1;
            int d = depth[u] + depth[v] - 2 * depth[LCA(u, v)];
            if (d > 0) ans[i] = power2[d - 1];
        }
        return ans;

        void DFS(int u)
        {
            foreach (int v in g[u])
            {
                if (v == parent[u][0]) continue;
                parent[v][0] = u;
                depth[v] = depth[u] + 1;
                for (int i = 1; i < MAX; i++)
                {
                    parent[v][i] = parent[parent[v][i - 1]][i - 1];
                }
                DFS(v);
            }
        }

        int LCA(int u, int v)
        {
            if (depth[u] < depth[v]) (u, v) = (v, u);
            for (int i = MAX - 1; i >= 0; i--)
            {
                if (depth[u] - (1 << i) >= depth[v])
                {
                    u = parent[u][i];
                }
            }
            if (u == v) return u;
            for (int i = MAX - 1; i >= 0; i--)
            {
                if (parent[u][i] != parent[v][i])
                {
                    u = parent[u][i];
                    v = parent[v][i];
                }
            }
            return parent[u][0];
        }
    }
}
