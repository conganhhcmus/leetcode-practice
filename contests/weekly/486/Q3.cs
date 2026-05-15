public class Solution
{
    public int SpecialNodes(int n, int[][] edges, int x, int y, int z)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = [];
        foreach (int[] e in edges)
        {
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }
        int MAX = 20;
        int[][] parent = new int[n][];
        for (int i = 0; i < n; i++) parent[i] = new int[MAX];
        int[] depth = new int[n];
        int[] log2 = new int[n];
        log2[1] = 0;
        for (int i = 2; i < n; i++)
        {
            log2[i] = log2[i / 2] + 1;
        }
        Dfs(0);
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int a = Dist(i, x);
            int b = Dist(i, y);
            int c = Dist(i, z);
            if (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a)
            {
                ans++;
            }
        }
        return ans;

        void Dfs(int u)
        {
            foreach (int v in graph[u])
            {
                if (v == parent[u][0]) continue;
                depth[v] = depth[u] + 1;
                parent[v][0] = u;
                for (int i = 1; i < MAX; i++)
                {
                    parent[v][i] = parent[parent[v][i - 1]][i - 1];
                }
                Dfs(v);
            }
        }

        int Lca(int u, int v)
        {
            if (depth[u] != depth[v])
            {
                if (depth[u] < depth[v]) (u, v) = (v, u);
                int diff = depth[u] - depth[v];
                for (int i = 0; (1 << i) <= diff; i++)
                {
                    if ((diff & (1 << i)) != 0)
                    {
                        u = parent[u][i];
                    }
                }
            }
            if (u == v) return u;
            int k = log2[depth[u]];
            for (int i = k; i >= 0; i--)
            {
                if (parent[u][i] != parent[v][i])
                {
                    u = parent[u][i];
                    v = parent[v][i];
                }
            }
            return parent[u][0];
        }

        int Dist(int a, int b)
        {
            return depth[a] + depth[b] - 2 * depth[Lca(a, b)];
        }
    }
}
