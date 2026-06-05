public class Solution
{
    public long InteractionCosts(int n, int[][] edges, int[] group)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = [];
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }
        Dictionary<int, int> total = [];
        foreach (int g in group)
        {
            total[g] = total.GetValueOrDefault(g, 0) + 1;
        }
        long ans = 0L;
        Dfs(0, -1);
        return ans;

        Dictionary<int, int> Dfs(int u, int p)
        {
            Dictionary<int, int> cur = [];
            cur[group[u]] = 1;
            foreach (int v in graph[u])
            {
                if (v == p) continue;
                var child = Dfs(v, u);
                foreach (var kv in child)
                {
                    int g = kv.Key;
                    long x = kv.Value;
                    ans += x * (total[g] - x);
                }

                foreach (var kv in child)
                {
                    cur[kv.Key] = cur.GetValueOrDefault(kv.Key, 0) + kv.Value;
                }
            }
            return cur;
        }
    }
}

