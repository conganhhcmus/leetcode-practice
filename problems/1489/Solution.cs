public class Solution
{
    public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
    {
        int m = edges.Length;
        List<(int u, int v, int w, int i)> list = [];
        for (int i = 0; i < m; i++)
        {
            list.Add((edges[i][0], edges[i][1], edges[i][2], i));
        }
        list.Sort((a, b) => a.w.CompareTo(b.w));
        int baseWeight = BuildMST(n, list, -1, -1);
        List<int> critical = [], pseudo = [];
        for (int i = 0; i < list.Count; i++)
        {
            var (_, _, _, idx) = list[i];
            // try skip it
            int skipWeight = BuildMST(n, list, i, -1);
            if (skipWeight > baseWeight)
            {
                critical.Add(idx);
            }
            else
            {
                // force it
                int forceWeight = BuildMST(n, list, -1, i);
                if (forceWeight == baseWeight)
                {
                    pseudo.Add(idx);
                }
            }
        }
        return [critical, pseudo];
    }

    int BuildMST(int n, List<(int u, int v, int w, int i)> list, int skip, int force)
    {
        int total = 0;
        int used = 0;
        UnionFind uf = new(n);
        if (force != -1)
        {
            var (u, v, w, _) = list[force];
            if (uf.Union(u, v))
            {
                total += w;
                used++;
            }
        }
        for (int i = 0; i < list.Count; i++)
        {
            var (u, v, w, _) = list[i];
            if (i == skip) continue;
            if (uf.Union(u, v))
            {
                total += w;
                used++;
            }
        }
        if (used == n - 1) return total;
        return int.MaxValue;
    }

    class UnionFind
    {
        int[] parent;
        public UnionFind(int n)
        {
            parent = new int[n];
            for (int i = 0; i < n; i++) parent[i] = i;
        }

        public int Find(int x)
        {
            if (parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }

        public bool Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return false;
            if (x > y) (x, y) = (y, x);
            parent[y] = x;
            return true;
        }
    }
}
