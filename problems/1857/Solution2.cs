#if DEBUG
namespace Problems_1857_2;
#endif

public class Solution
{
    public int LargestPathValue(string colors, int[][] edges)
    {
        int n = colors.Length;
        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = [];
        }
        int[] indegree = new int[n];
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
            indegree[v]++;
        }

        int[,] dp = new int[n, 26];
        Queue<int> queue = [];
        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0) queue.Enqueue(i);
        }
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            int idx = colors[curr] - 'a';
            dp[curr, idx]++;

            foreach (int next in adj[curr])
            {
                for (int i = 0; i < 26; i++)
                {
                    dp[next, i] = Math.Max(dp[next, i], dp[curr, i]);
                }
                if (--indegree[next] == 0) queue.Enqueue(next);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (indegree[i] > 0) return -1;
        }
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                ret = Math.Max(ret, dp[i, j]);
            }
        }
        return ret;
    }
}