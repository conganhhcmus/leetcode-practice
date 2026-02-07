public class Solution
{
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
    {
        UnionFind uf = new(n);
        for (int i = 1; i < n; i++)
        {
            if (Math.Abs(nums[i] - nums[i - 1]) <= maxDiff)
            {
                uf.Union(i, i - 1);
            }
        }

        bool[] ret = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int u = queries[i][0], v = queries[i][1];
            ret[i] = uf.Find(u) == uf.Find(v);
        }
        return ret;
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