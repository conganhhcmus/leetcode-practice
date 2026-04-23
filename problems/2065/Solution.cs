public class Solution
{
    public int MaximalPathQuality(int[] values, int[][] edges, int maxTime)
    {
        int n = values.Length;
        bool[] visited = new bool[n];
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
        void Dfs(int curr, int time, int val)
        {
            if (time > maxTime) return;
            if (curr == 0)
            {
                ans = Math.Max(ans, val);
            }
            foreach (int[] neighbor in graph[curr])
            {
                int next = neighbor[0], need = neighbor[1];
                if (visited[next])
                {
                    // go back
                    Dfs(next, time + need, val);
                }
                else
                {
                    // go next
                    visited[next] = true;
                    Dfs(next, time + need, val + values[next]);
                    visited[next] = false;
                }
            }
        }

        visited[0] = true;
        Dfs(0, 0, values[0]);
        return ans;
    }
}
