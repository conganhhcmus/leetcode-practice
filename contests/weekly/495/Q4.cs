public class Solution
{
    int[] parent;
    int[] rank;

    (int root, int parity) Find(int x)
    {
        if (parent[x] != x)
        {
            var (root, parity) = Find(parent[x]);
            rank[x] ^= parity;
            parent[x] = root;
        }
        return (parent[x], rank[x]);
    }

    void Union(int rootU, int rootV, int parity)
    {
        parent[rootU] = rootV;
        rank[rootU] = parity;
    }

    public int NumberOfEdgesAdded(int n, int[][] edges)
    {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }
        int ans = 0;
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], w = e[2];
            var (rootU, rankU) = Find(u);
            var (rootV, rankV) = Find(v);
            if (rootU != rootV)
            {
                Union(rootU, rootV, rankU ^ rankV ^ w);
                ans++;
            }
            else
            {
                if ((rankU ^ rankV) == w)
                {
                    ans++;
                }
            }
        }
        return ans;
    }
}