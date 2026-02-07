public class Solution
{
    public int MagnificentSets(int n, int[][] edges)
    {
        Dictionary<int, HashSet<int>> graph = [];
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            if (!graph.ContainsKey(u)) graph[u] = [];
            if (!graph.ContainsKey(v)) graph[v] = [];
            graph[u].Add(v);
            graph[v].Add(u);
        }
        int[] colors = new int[n + 1];
        Array.Fill(colors, -1);
        for (int node = 0; node < n; node++)
        {
            if (colors[node] != -1) continue;
            colors[node] = 0;
            if (!IsBipartite(graph, node, colors)) return -1;
        }

        int[] dist = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dist[i] = GetLongestShortestPath(graph, n, i);
        }
        int ans = 0;
        bool[] visited = new bool[n + 1];
        for (int i = 1; i <= n; i++)
        {
            if (visited[i]) continue;
            ans += GetMaxGroups(graph, visited, i, dist);
        }
        return ans;
    }

    private bool IsBipartite(Dictionary<int, HashSet<int>> graph, int node, int[] colors)
    {
        foreach (var neighbor in graph.GetValueOrDefault(node, []))
        {
            if (colors[neighbor] == colors[node]) return false;
            if (colors[neighbor] != -1) continue;
            colors[neighbor] = (colors[node] + 1) % 2;
            if (!IsBipartite(graph, neighbor, colors)) return false;
        }
        return true;
    }

    private int GetLongestShortestPath(Dictionary<int, HashSet<int>> graph, int n, int start)
    {
        int distance = 0;
        bool[] visited = new bool[n + 1];
        Queue<int> queue = [];
        queue.Enqueue(start);
        visited[start] = true;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            distance++;
            for (int i = 0; i < size; i++)
            {
                int node = queue.Dequeue();
                foreach (var neighbor in graph.GetValueOrDefault(node, []))
                {
                    if (visited[neighbor]) continue;
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return distance;
    }

    private int GetMaxGroups(Dictionary<int, HashSet<int>> graph, bool[] visited, int start, int[] dist)
    {
        int maxGroup = dist[start];
        visited[start] = true;
        Queue<int> queue = [];
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (var neighbor in graph.GetValueOrDefault(node, []))
            {
                if (visited[neighbor]) continue;
                visited[neighbor] = true;
                queue.Enqueue(neighbor);
                maxGroup = Math.Max(maxGroup, dist[neighbor]);
            }
        }
        return maxGroup;
    }
}