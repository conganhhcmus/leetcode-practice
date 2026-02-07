public class Solution
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = [];
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }
        bool[] visited = new bool[n];
        int completed = 0;
        for (int i = 0; i < n; i++)
        {
            if (visited[i]) continue;
            Queue<int> queue = [];
            List<int> component = [];
            queue.Enqueue(i);
            visited[i] = true;
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                component.Add(curr);
                foreach (var neighbor in graph[curr])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            bool isCompleted = true;
            foreach (int node in component)
            {
                if (graph[node].Count != component.Count - 1)
                {
                    isCompleted = false;
                    break;
                }
            }
            if (isCompleted) completed++;
        }

        return completed;
    }
}