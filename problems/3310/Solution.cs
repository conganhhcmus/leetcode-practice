public class Solution
{
    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        foreach (int[] e in invocations)
        {
            int u = e[0], v = e[1];
            g[u].Add(v);
        }
        bool[] suspicious = new bool[n];
        suspicious[k] = true;
        Queue<int> q = [];
        q.Enqueue(k);
        while (q.Count > 0)
        {
            int u = q.Dequeue();
            foreach (int v in g[u])
            {
                if (suspicious[v]) continue;
                suspicious[v] = true;
                q.Enqueue(v);
            }
        }

        int[] pa = new int[n];
        for (int i = 0; i < n; i++)
        {
            pa[i] = i;
        }

        int Find(int x)
        {
            if (pa[x] == x) return x;
            return pa[x] = Find(pa[x]);
        }

        void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return;
            if (x > y) (x, y) = (y, x);
            pa[y] = x;
        }

        foreach (int[] e in invocations)
        {
            int u = e[0], v = e[1];
            Union(u, v);
        }

        Dictionary<int, List<int>> group = [];
        Dictionary<int, int> cnt = [];
        for (int i = 0; i < n; i++)
        {
            int root = Find(i);
            if (!group.ContainsKey(root)) group[root] = [];
            group[root].Add(i);
            if (suspicious[i]) cnt[root] = cnt.GetValueOrDefault(root, 0) + 1;
        }
        List<int> ans = [];
        foreach (var kv in group)
        {
            if (kv.Value.Count == cnt.GetValueOrDefault(kv.Key)) continue;
            ans.AddRange(kv.Value);
        }
        return ans;
    }
}
