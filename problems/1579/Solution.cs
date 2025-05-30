#if DEBUG
namespace Problems_1579;
#endif

public class Solution
{
    public int MaxNumEdgesToRemove(int n, int[][] edges)
    {
        UnionFind uf1 = new(n + 1);
        UnionFind uf2 = new(n + 1);
        Array.Sort(edges, (a, b) => b[0] - a[0]);
        int count = 0;
        foreach (int[] e in edges)
        {
            if (e[0] == 1)
            {
                int u = e[1], v = e[2];
                if (uf1.Union(u, v)) count++;
            }
            else if (e[0] == 2)
            {
                int u = e[1], v = e[2];
                if (uf2.Union(u, v)) count++;
            }
            else
            {
                int u = e[1], v = e[2];
                if (uf1.Union(u, v) && uf2.Union(u, v)) count++;
            }
        }

        for (int i = 1; i <= n; i++)
        {
            if (uf1.Find(1) != uf1.Find(i)) return -1;
            if (uf2.Find(1) != uf2.Find(i)) return -1;
        }

        return edges.Length - count;
    }
}

public class UnionFind
{
    private readonly int[] parent;
    private readonly int[] rank;

    public UnionFind(int n)
    {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }
    }

    public bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) return false;
        if (rank[rootX] <= rank[rootY])
        {
            parent[rootX] = rootY;
            rank[rootY]++;
        }
        else if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
            rank[rootX]++;
        }
        return true;
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }
}