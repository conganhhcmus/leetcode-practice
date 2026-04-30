public class Solution
{
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        if (source == target) return 0;
        int n = routes.Length;
        Dictionary<int, List<int>> graph = [];
        for (int i = 0; i < n; i++)
        {
            foreach (int j in routes[i])
            {
                if (!graph.ContainsKey(j))
                {
                    graph[j] = [];
                }
                graph[j].Add(i);
            }
        }
        Queue<int> queue = [];
        bool[] visited = new bool[n];
        foreach (int u in graph.GetValueOrDefault(source, []))
        {
            visited[u] = true;
            queue.Enqueue(u);
        }
        int step = 1;
        while (queue.Count > 0)
        {
            int s = queue.Count;
            for (int i = 0; i < s; i++)
            {
                int u = queue.Dequeue();
                foreach (int next in routes[u])
                {
                    if (next == target) return step;
                    foreach (int v in graph.GetValueOrDefault(next, []))
                    {
                        if (visited[v]) continue;
                        visited[v] = true;
                        queue.Enqueue(v);
                    }
                }
            }
            step++;
        }

        return -1;
    }
}
