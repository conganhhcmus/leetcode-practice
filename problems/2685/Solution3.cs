#if DEBUG
namespace Problems_2685_3;
#endif

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
            int[] info = new int[2];
            DFS(graph, i, visited, info);
            if (info[0] * (info[0] - 1) == info[1]) completed++;
        }

        return completed;
    }

    void DFS(List<int>[] graph, int vertex, bool[] visited, int[] info)
    {
        visited[vertex] = true;
        info[0]++;
        info[1] += graph[vertex].Count;
        foreach (var neighbor in graph[vertex])
        {
            if (!visited[neighbor]) DFS(graph, neighbor, visited, info);
        }
    }
}