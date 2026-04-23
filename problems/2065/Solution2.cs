public class Solution
{
    public int MaximalPathQuality(int[] values, int[][] edges, int maxTime)
    {
        int n = values.Length;
        int[] visited = new int[n];
        List<int[]>[] graph = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], t = e[2];
            graph[u].Add([v, t]);
            graph[v].Add([u, t]);
        }
        int ans = 0;
        Dfs(0, 0, 0);
        return ans;

        void Dfs(int u, int time, int quality)
        {
            if (visited[u]++ == 0)
            {
                quality += values[u];
            }
            if (u == 0) ans = Math.Max(ans, quality);

            foreach (int[] next in graph[u])
            {
                int v = next[0], t = next[1];
                if (time + t <= maxTime)
                {
                    Dfs(v, time + t, quality);
                }
            }
            visited[u]--;
        }
    }
}
