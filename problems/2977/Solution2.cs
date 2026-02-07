public class Solution
{
    long INF = long.MaxValue / 2;

    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost)
    {
        // Use actual strings as keys to avoid hash collision in graph
        Dictionary<string, int> mapIndex = new();
        int V = 0;
        for (int i = 0; i < cost.Length; i++)
        {
            if (!mapIndex.ContainsKey(original[i]))
                mapIndex[original[i]] = V++;
            if (!mapIndex.ContainsKey(changed[i]))
                mapIndex[changed[i]] = V++;
        }

        long[,] dist = new long[V, V];
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
                dist[i, j] = INF;
            dist[i, i] = 0;
        }

        for (int i = 0; i < cost.Length; i++)
        {
            int u = mapIndex[original[i]], v = mapIndex[changed[i]], c = cost[i];
            dist[u, v] = Math.Min(dist[u, v], c);
        }

        // Floyd-Warshall
        for (int k = 0; k < V; k++)
            for (int i = 0; i < V; i++)
                for (int j = 0; j < V; j++)
                    dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);

        // Collect valid lengths
        HashSet<int> validLengths = new();
        foreach (var s in mapIndex.Keys)
            validLengths.Add(s.Length);

        int n = source.Length;
        long[] dp = new long[n + 1];
        Array.Fill(dp, INF);
        dp[n] = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            // If characters match, skip with no cost
            if (source[i] == target[i])
                dp[i] = Math.Min(dp[i], dp[i + 1]);

            foreach (int len in validLengths)
            {
                int j = i + len;
                if (j > n) continue;

                string srcSub = source.Substring(i, len);
                string tgtSub = target.Substring(i, len);

                if (srcSub == tgtSub)
                    dp[i] = Math.Min(dp[i], dp[j]);

                if (mapIndex.TryGetValue(srcSub, out int u) && mapIndex.TryGetValue(tgtSub, out int v))
                    dp[i] = Math.Min(dp[i], dist[u, v] + dp[j]);
            }
        }

        return dp[0] >= INF ? -1 : dp[0];
    }
}