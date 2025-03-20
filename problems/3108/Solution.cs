#if DEBUG
namespace Problems_3108;
#endif

public class Solution
{
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
        int qLen = query.Length;
        int[] ret = new int[qLen];
        UnionFind uf = new UnionFind(n);
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1], w = edge[2];
            uf.Union(u, v, w);
        }
        for (int i = 0; i < qLen; i++)
        {
            int u = query[i][0], v = query[i][1];
            int parentU = uf.Find(u);
            int parentV = uf.Find(v);
            if (parentU != parentV) ret[i] = -1;
            else ret[i] = uf.Cost(u);
        }

        return ret;
    }
}

public class UnionFind
{
    int[] parent;
    int[] cost;
    public UnionFind(int n)
    {
        parent = new int[n];
        cost = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            cost[i] = -1;
        }
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }

    public int Cost(int x)
    {
        int rootX = Find(x);
        return cost[rootX];
    }

    public void Union(int x, int y, int weight)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        parent[rootY] = rootX;
        cost[rootX] = cost[rootY] & weight & cost[rootX];
        // -1 & a = a
    }
}