#if DEBUG
namespace Problems_1857;
#endif

public class Solution
{
    public int LargestPathValue(string colors, int[][] edges)
    {
        int n = colors.Length;
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
        }

        if (HasCycle(graph, n)) return -1;
        int ret = 1;

        int[] dp = new int[n];
        HashSet<char> set = [.. colors];
        foreach (char c in set)
        {
            Array.Clear(dp);
            bool[] visited = new bool[n];
            PriorityQueue<int, int> pq = new();
            for (int i = 0; i < n; i++)
            {
                if (visited[i]) continue;
                dp[i] = colors[i] == c ? 1 : 0;
                pq.Enqueue(i, -dp[i]);
                while (pq.Count > 0)
                {
                    int curr = pq.Dequeue();
                    foreach (int next in graph[curr])
                    {
                        visited[next] = true;
                        int w = colors[next] == c ? 1 : 0;
                        if (dp[curr] + w > dp[next])
                        {
                            dp[next] = dp[curr] + w;
                            pq.Enqueue(next, -dp[next]);
                        }
                    }
                }
            }
            ret = Math.Max(ret, dp.Max());
        }

        return ret;
    }

    bool HasCycle(List<int>[] graph, int n)
    {
        bool[] visited = new bool[n];
        bool[] colored = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (!visited[i] && DFS(i, graph, visited, colored)) return true;
        }

        return false;
    }

    bool DFS(int u, List<int>[] graph, bool[] visited, bool[] colored)
    {
        visited[u] = true;
        colored[u] = true;
        foreach (int v in graph[u])
        {
            if (!visited[v] && DFS(v, graph, visited, colored)) return true;
            if (colored[v]) return true;
        }
        colored[u] = false;
        return false;
    }
}