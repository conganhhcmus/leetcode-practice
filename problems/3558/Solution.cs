public class Solution
{
    int MOD = 1_000_000_007;

    long Power(long a, long b)
    {
        long ans = 1L;
        while (b > 0)
        {
            if ((b & 1) != 0) ans = ans * a % MOD;
            a = a * a % MOD;
            b >>= 1;
        }
        return ans;
    }

    public int AssignEdgeWeights(int[][] edges)
    {
        int n = edges.Length + 1;
        List<int>[] g = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) g[i] = [];
        foreach (int[] e in edges)
        {
            g[e[0]].Add(e[1]);
            g[e[1]].Add(e[0]);
        }
        Queue<int> queue = [];
        queue.Enqueue(1);
        bool[] vis = new bool[n + 1];
        vis[1] = true;
        int depth = 0;
        while (queue.Count > 0)
        {
            int s = queue.Count;
            while (s-- > 0)
            {
                int u = queue.Dequeue();
                foreach (int v in g[u])
                {
                    if (vis[v] == false)
                    {
                        vis[v] = true;
                        queue.Enqueue(v);
                    }
                }
            }
            depth++;
        }

        // depth = x
        // odd = 1, 3, 5, ... x
        // Ckn: C1x + C3x + C5x + ...
        depth--;
        long ans = 0L;
        long num = 1L, den = 1L;
        for (int i = 1; i <= depth; i++)
        {
            num = num * (depth - i + 1) % MOD;
            den = den * i % MOD;
            if (i % 2 == 1) ans = (ans + num * Power(den, MOD - 2) % MOD) % MOD;
        }

        return (int)ans;
    }
}
