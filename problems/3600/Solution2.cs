public class Solution
{
    public int MaxStability(int n, int[][] edges, int k)
    {
        int mustMinStability = int.MaxValue;
        int[] parent = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }
        DSU dsuInit = new(parent);
        List<int[]> optionalEdge = [];
        int selectedEdge = 0;
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], s = e[2], m = e[3];
            if (m == 1)
            {
                mustMinStability = Math.Min(mustMinStability, s);
                if (selectedEdge == n - 1 || dsuInit.Find(u) == dsuInit.Find(v)) return -1;
                dsuInit.Union(u, v);
                selectedEdge++;
            }
            else
            {
                optionalEdge.Add([u, v, s]);
            }
        }
        optionalEdge.Sort((a, b) => b[2] - a[2]);
        int ans = -1, l = 0, r = mustMinStability;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            int selected = selectedEdge;
            int doubledCount = 0;
            DSU dsu = new((int[])dsuInit.Parent.Clone());
            foreach (var e in optionalEdge)
            {
                int u = e[0], v = e[1], s = e[2];

                if (dsu.Find(u) == dsu.Find(v)) continue;
                if (s >= mid)
                {
                    selected++;
                    dsu.Union(u, v);
                }
                else if (doubledCount < k && 2 * s >= mid)
                {
                    doubledCount++;
                    selected++;
                    dsu.Union(u, v);
                }
                else
                {
                    break;
                }
                if (selected == n - 1) break;
            }
            if (selected == n - 1)
            {
                ans = mid;
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }
        return ans;
    }
}

public class DSU
{
    int[] parent;
    public DSU(int[] init)
    {
        parent = init;
    }

    public int[] Parent => parent;

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }

    public void Union(int x, int y)
    {
        parent[Find(x)] = Find(y);
    }
}