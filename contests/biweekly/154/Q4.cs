#if DEBUG
namespace Biweekly_154_Q4;
#endif

public class Solution
{
    int[] inTime, outTime, flat, parent, depth;
    int timer;
    public int[] TreeQueries(int n, int[][] edges, int[][] queries)
    {
        inTime = new int[n + 1];
        outTime = new int[n + 1];
        flat = new int[n + 2];
        parent = new int[n + 1];
        depth = new int[n + 1];

        var tree = new List<(int v, int w)>[n + 1];
        for (int i = 1; i <= n; i++) tree[i] = [];
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1], w = edge[2];
            tree[u].Add((v, w));
            tree[v].Add((u, w));
        }

        timer = 0;
        DFS(1, 0, 0, tree);

        var bit = new FenwickTree(n + 1);
        for (int u = 2; u <= n; u++)
        {
            int w = flat[inTime[u]];
            bit.Update(inTime[u], w);
            bit.Update(outTime[u] + 1, -w);
        }

        var result = new List<int>();
        foreach (var q in queries)
        {
            if (q[0] == 1)
            {
                int u = q[1], v = q[2], newW = q[3];
                int child = parent[v] == u ? v : u;
                int oldW = flat[inTime[child]];
                int delta = newW - oldW;
                flat[inTime[child]] = newW;
                bit.Update(inTime[child], delta);
                bit.Update(outTime[child] + 1, -delta);
            }
            else
            {
                int x = q[1];
                result.Add(bit.Query(inTime[x]));
            }
        }

        return result.ToArray();
    }

    void DFS(int u, int p, int wFromParent, List<(int v, int w)>[] tree)
    {
        inTime[u] = ++timer;
        flat[inTime[u]] = wFromParent;
        parent[u] = p;
        depth[u] = depth[p] + 1;

        foreach (var (v, w) in tree[u])
        {
            if (v == p) continue;
            DFS(v, u, w, tree);
        }
        outTime[u] = timer;
    }
}

public class FenwickTree
{
    int[] bit;
    int n;
    public FenwickTree(int size)
    {
        n = size;
        bit = new int[n + 2];
    }

    public void Update(int i, int val)
    {
        i++;
        while (i <= n)
        {
            bit[i] += val;
            i += i & -i;
        }
    }

    public int Query(int i)
    {
        i++;
        int sum = 0;
        while (i > 0)
        {
            sum += bit[i];
            i -= i & -i;
        }
        return sum;
    }
}