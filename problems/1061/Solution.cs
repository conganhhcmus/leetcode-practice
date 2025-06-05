#if DEBUG
namespace Problems_1061;
#endif

public class Solution
{
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        int n = s1.Length;
        UnionFind uf = new(26);
        for (int i = 0; i < n; i++)
        {
            int a = s1[i] - 'a';
            int b = s2[i] - 'a';
            uf.Union(a, b);
        }

        StringBuilder sb = new();
        foreach (char c in baseStr)
        {
            int root = uf.Find(c - 'a');
            sb.Append((char)(root + 'a'));
        }
        return sb.ToString();
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
            rank[i] = -i;
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
            // rank[rootY]++;
        }
        else if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
            // rank[rootX]++;
        }
        return true;
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }
}