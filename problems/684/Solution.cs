#if DEBUG
namespace Problems_684;
#endif

public class Solution
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        // Build graph
        Dictionary<int, HashSet<int>> graph = [];
        int n = 0, k = edges.Length;
        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            if (!graph.ContainsKey(u))
            {
                graph[u] = [];
            }
            if (!graph.ContainsKey(v))
            {
                graph[v] = [];
            }
            graph[u].Add(v);
            graph[v].Add(u);
            n = Math.Max(n, Math.Max(u, v));
        }
        for (int i = k - 1; i >= 0; i--)
        {
            // remove edge from graph
            int u = edges[i][0];
            int v = edges[i][1];
            graph[u].Remove(v);
            graph[v].Remove(u);
            if (!HasCycle(graph, n + 1))
            {
                return edges[i];
            }
            graph[u].Add(v);
            graph[v].Add(u);
        }
        return [];
    }

    private bool HasCycle(Dictionary<int, HashSet<int>> graph, int n)
    {
        bool[] visited = new bool[n];
        for (int i = 1; i < n; i++)
        {
            if (visited[i]) continue;
            Queue<(int, int)> queue = [];
            queue.Enqueue((i, -1));
            visited[i] = true;
            while (queue.Count > 0)
            {
                var (curr, parent) = queue.Dequeue();
                foreach (var next in graph.GetValueOrDefault(curr, []))
                {
                    if (visited[next] && next != parent) return true;
                    if (visited[next] || next == parent) continue;
                    visited[next] = true;
                    queue.Enqueue((next, curr));
                }
            }
        }

        return false;
    }
}