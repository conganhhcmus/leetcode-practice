public class Solution
{
    long INF = long.MaxValue / 2;

    int Add(Trie root, string word, ref int index)
    {
        Trie cur = root;
        foreach (char c in word)
        {
            int i = c - 'a';
            if (cur.node[i] == null)
            {
                cur.node[i] = new();
            }
            cur = cur.node[i];
        }
        if (cur.id == -1)
        {
            cur.id = index++;
        }
        return cur.id;
    }

    void Update(ref long x, long y)
    {
        if (x == -1 || x > y)
        {
            x = y;
        }
    }

    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost)
    {
        int n = source.Length;
        int m = original.Length;
        long[,] dist = new long[m * 2, m * 2];
        for (int i = 0; i < m * 2; i++)
        {
            for (int j = 0; j < m * 2; j++)
            {
                dist[i, j] = INF;
            }
            dist[i, i] = 0;
        }
        Trie root = new();
        int p = 0;
        for (int i = 0; i < m; i++)
        {
            int u = Add(root, original[i], ref p);
            int v = Add(root, changed[i], ref p);
            dist[u, v] = Math.Min(dist[u, v], cost[i]);
        }

        for (int k = 0; k < p; k++)
        {
            for (int i = 0; i < p; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                }
            }
        }

        long[] dp = new long[n];
        Array.Fill(dp, -1);
        for (int j = 0; j < n; j++)
        {
            if (j > 0 && dp[j - 1] == -1) continue;
            long baseVal = (j == 0) ? 0 : dp[j - 1];
            if (source[j] == target[j])
            {
                Update(ref dp[j], baseVal);
            }

            Trie u = root;
            Trie v = root;
            for (int i = j; i < n; i++)
            {
                u = u.node[source[i] - 'a'];
                v = v.node[target[i] - 'a'];

                if (u == null || v == null) break;
                if (u.id != -1 && v.id != -1 && dist[u.id, v.id] != INF)
                {
                    Update(ref dp[i], baseVal + dist[u.id, v.id]);
                }
            }
        }

        return dp[n - 1];
    }
}

public class Trie
{
    public Trie[] node = new Trie[26];
    public int id = -1;
}