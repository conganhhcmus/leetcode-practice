
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
        int[] down = new int[n];
        int[] up = new int[n];
        // down[i] = max sub graph contain i -> all child
        // up[i] = max sub graph not contain i -> all parent
        Dfs1(0, -1);
        Dfs2(0, -1);
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            ans[i] = down[i] + up[i];
        }
        return ans;

        void Dfs1(int u, int p)
        {
            down[u] = w[u];
            foreach (int v in g[u])
            {
                if (v == p) continue;
                Dfs1(v, u);
                down[u] += Math.Max(0, down[v]);
            }
        }

        void Dfs2(int u, int p)
        {
            foreach (int v in g[u])
            {
                if (v == p) continue;
                up[v] = Math.Max(0, up[u] + down[u] - Math.Max(0, down[v]));
                Dfs2(v, u);
            }
        }
    }
}
