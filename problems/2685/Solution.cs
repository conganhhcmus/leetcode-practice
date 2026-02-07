public class Solution
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        UnionFind uf = new UnionFind(n);
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            uf.Union(u, v);
        }
        int[] edgeCount = new int[n];
        foreach (var edge in edges)
        {
            int root = uf.Find(edge[0]);
            edgeCount[root]++;
        }

        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (uf.Find(i) == i)
            {
                int size = uf.GetSize(i);
                if (edgeCount[i] == size * (size - 1) / 2) count++;
            }
        }

        return count;
    }
}

public class UnionFind
{
    int[] parents;
    int[] sizes;

    public UnionFind(int n)
    {
        parents = new int[n];
        sizes = new int[n];
        for (int i = 0; i < n; i++)
        {
            parents[i] = i;
            sizes[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (parents[x] == x) return x;
        return parents[x] = Find(parents[x]);
    }

    public int GetSize(int x)
    {
        return sizes[Find(x)];
    }

    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) return;
        if (sizes[rootX] >= sizes[rootY])
        {
            parents[rootY] = rootX;
            sizes[rootX] += sizes[rootY];
        }
        else
        {
            parents[rootX] = rootY;
            sizes[rootY] += sizes[rootX];
        }
    }
}