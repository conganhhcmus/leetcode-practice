public class Solution
{
    private Dictionary<int, List<(int u, int w)>> BuildGraph(int[][] edges)
    {
        Dictionary<int, List<(int u, int w)>> graph = [];
        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = [];
            }
            graph[edge[1]].Add((edge[0], edge[2]));
        }
        return graph;
    }

    bool CanMoveAllToZero(Dictionary<int, List<(int u, int w)>> graph, int n, int w)
    {
        Queue<int> queue = [];
        queue.Enqueue(0);
        bool[] visited = new bool[n];
        visited[0] = true;
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (var neighbor in graph.GetValueOrDefault(node, []))
            {
                if (!visited[neighbor.u] && neighbor.w <= w)
                {
                    queue.Enqueue(neighbor.u);
                    visited[neighbor.u] = true;
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (!visited[i]) return false;
        }
        return true;
    }

    public int MinMaxWeight(int n, int[][] edges, int threshold)
    {
        var graph = BuildGraph(edges);
        const int max = 1_000_001;
        int l = 1, r = max, ans = -1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            if (CanMoveAllToZero(graph, n, mid))
            {
                ans = mid;
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }

        return ans;
    }
}